using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;
using System;


namespace GURHelper
{
    public enum TestTrigger
    {
        TIME, ONLOAD, ONUNLOAD, CUSTOM
    }

    public class GURManager : MonoBehaviour
    {
        //instancia singleton
        private static GURManager instance;
        //getter
        public static GURManager Instance { get { return instance; } }

        [Tooltip("Objeto que contiene el Canvas que se va a utilizar (prefab en la carpeta del package)")]
        public GameObject GURCanvas;
        [Tooltip("Elige cuando se va a activar la prueba.")]
        public TestTrigger triggerType;
        [HideInInspector]
        public float minutes;
        [HideInInspector]
        public bool showMinutes = false;
        float previousTimeScale = 1f;
        bool custom = false;

        [Tooltip("GURManager comprobará que la escena a descargar sea esta antes de lanzar el test en modo UNLOAD.")]
        public string unloadSceneName = "";


        //TRACKER RELATED
        [HideInInspector]
        public bool[] persistences = new bool[Enum.GetValues(typeof(persistenceType)).Length - 1];
        [HideInInspector]
        public bool[] serializers = new bool[Enum.GetValues(typeof(serializerType)).Length - 1];
        [Tooltip("Elige el tipo de tracker necesario para la prueba que se va a realizar.")]
        public trackerType trackerType = trackerType.BASIC;
        private Tracker myTracker;

        Scene testScene;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                //realizamos la inicalización sólo la primera vez que se cree la instancia
                InitTest();
                InitTracker();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            SceneManager.LoadScene("TestScene", LoadSceneMode.Additive);
            myTracker.TrackSynchroEvent(myTracker.SessionStart());
        }
        private void OnApplicationQuit()
        {
            myTracker.TrackSynchroEvent(myTracker.SessionEnd());
        }

        private void OnEnable()
        {
            if(triggerType == TestTrigger.ONUNLOAD)
            {
                // Suscribir al evento de cambio de escena
                SceneManager.sceneUnloaded += EscenaDescargada;
            }
        }
        // Este método se llama cuando el objeto es desactivado
        private void OnDisable()
        {
            if(triggerType == TestTrigger.ONUNLOAD)
            {
                // Desuscribir del evento para evitar fugas de memoria
                SceneManager.sceneUnloaded -= EscenaDescargada;
            }
        }
        private void EscenaDescargada(Scene escena)
        {
            if (escena.name == "unloadSceneName" /*testScene == isvalid*/)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestScene"));
            }
        }

        /// <summary>
        /// Método para actualizar los valores que se ven en el editor: cuadro de texto para añadir los minutos que durará la prueba
        /// Este comportamiento está definido en GURManagerEditor.cs
        /// </summary>
        private void OnValidate()
        {
            showMinutes = triggerType == TestTrigger.TIME;
        }
        private void OnSceneLoaded(Scene s, LoadSceneMode m)
        {

            Debug.Log("La escena " + s.name + "ha sido cargada, se procede a mostrar el test");
            ShowTest();
        }

        //--------------------------LÓGICA DEL MANAGER------------------------------------------------------

        /// <summary>
        /// Inicializará el tracker según los parámetros otorgados
        /// </summary>
        private void InitTracker()
        {
            myTracker = Tracker.Instance;
            myTracker.type = trackerType;
            //comprueba que se haya definido al menos un tipo de persistencia y un tipo de serializador. Si no, devuelve un warning.
            bool exist = (persistences.Any(x => x) && serializers.Any(x => x));
            if (!exist)
            {
                Debug.LogError("Ningún valor de persistencia y/o serializadores asignados al objeto con el componente GURManager. No se inicializará el tracker.");
                return;
            }

            //creamos una lista con los tipos de serializadores que se van a utilizar 
            //partiendo del array de booleanos, parseamos el indice del array a un valor en el enum serializerType, y posteriormente 
            //mapeamos ese enum en un objeto nuevo de una clase que implemente la interfaz Serializer.
            List<Serializer> sSystems = serializers
                .Select((value, index) => new { Value = value, Index = index })
                .Where(item => item.Value)
                //funcion anonima que parsea el tipo del enum serializerType en un nuevo objeto de tipo Serializer
                .Select(item =>
                {
                    serializerType enumValue = (serializerType)item.Index;
                    Serializer s = null;

                    // Realizar el mapeo desde el enum a la subclase correspondiente
                    switch (enumValue)
                    {
                        case serializerType.JSON:
                            s = new JsonSerializer();
                            break;
                        case serializerType.BINARY:
                            s = new BinarySerializer();
                            break;
                        case serializerType.NULL:
                            break;
                    }

                    return s;
                })
                .ToList();
            //creamos una lista con las persistencias que se han indicado que se quieren usar
            List<persistenceType> pSystems = persistences
                .Select((valor, indice) => new { Valor = valor, Indice = indice })
                .Where(item => item.Valor) 
                .Select(item => (persistenceType)item.Indice) 
                .ToList();

            //por cada sistema de serializacion, creamos un nuevo sistema de persistencia de los tipos indicados
            foreach (Serializer s in sSystems)
            {
                foreach(persistenceType p in pSystems)
                {
                    //coger tipo de persistencia
                    switch (p)
                    {
                        case persistenceType.FILE:
                            FilePersistence fp = new FilePersistence(s);
                            myTracker.AddPersistence(fp);
                            break;
                        case persistenceType.SERVER:
                            Debug.LogWarning("TO DO: Implementar server persistance");
                            //myTracker.AddPersistence(new ServerPersistence(s));
                            break;
                        case persistenceType.NULL:
                            break;
                    }
                }
            }

        }

        /// <summary>
        /// Método que se llamará cada vez que se inicialice una escena en la cual se quiera realizar un test de usuario.
        /// Se preparará el test para iniciarse según el parámetro asignado (tiempo, inicio o final de escena)
        /// </summary>
        private void InitTest()
        {

            ///en caso de que se quiera realizar la prueba cuando se cargue la escena actual, 
            ///se añaden los comportamientos al SceneManager
            ///en caso de que se haga por tiempo, se realiza un Invoke con un tiempo de espera de x minutos.
            GURCanvas.SetActive(false);
            switch (triggerType)
            {
                case TestTrigger.TIME:
                    Invoke("ShowTest", minutes * 60f);
                    break;
                case TestTrigger.ONLOAD:
                    SceneManager.sceneLoaded += OnSceneLoaded;
                    break;
                case TestTrigger.CUSTOM:
                    Console.WriteLine("RECUERDA: HACER LA LLAMADA EN TU LÓGICA A GurManager::instance.ShowTest()");
                    custom = true;
                    break;
                case TestTrigger.ONUNLOAD:

                    break;
            }
        }

        /// <summary>
        /// Método que hará visible el test
        /// </summary>
        public void ShowTest()
        {
            previousTimeScale = Time.timeScale;
            Debug.Log("mostrando test...");
            Time.timeScale = 0f;
            GURCanvas.SetActive(true);
            myTracker.TrackSynchroEvent(myTracker.TestStarted());

        }

        /// <summary>
        /// Método que hará desaparecer el test
        /// </summary>
        public void EndTest()
        {
            Time.timeScale = previousTimeScale;
            GURCanvas.SetActive(false);
            myTracker.TrackSynchroEvent(myTracker.TestEnd());
        }

    }
}