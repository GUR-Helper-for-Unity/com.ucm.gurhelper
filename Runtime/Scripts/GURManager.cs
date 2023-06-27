using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public enum TestTrigger
{
    TIME, ONLOAD, CUSTOM
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

    bool unload = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Método para hacer aparecer o desaparecer el cuadro de texto para añadir los minutos que durará la prueba.
    /// Así es más cómodo para el usuario, ya que sólo tendrá esta opción si está escogiendo que sea por tiempo.
    /// Este comportamiento está definido en GURManagerEditor.cs
    /// </summary>
    private void OnValidate()
    {
        showMinutes = triggerType == TestTrigger.TIME;
    }

    private void OnEnable()
    {
        //TO DO: Llamar a este método cuando corresponda, no en OnEnable
        InitTest();
    }
    private void OnDisable()
    {
        //if (unload)
        //{
        //    ShowTest();
        //    while (true)
        //    {

        //    }

        //}
    }

    /// <summary>
    /// Método que se llamará cada vez que se inicialice una escena en la cual se quiera
    /// realizar un test de usuario.
    /// Se preparará el test para iniciarse según el parámetro asignado (tiempo, inicio o final de escena)
    /// </summary>
    private void InitTest()
    {

        ///en caso de que se quiera realizar la prueba cuando se cargue o se descargue la escena actual, 
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
                unload = true;
                break;
        }
    }

    private void OnSceneLoaded(Scene s, LoadSceneMode m)
    {

        Debug.Log("La escena " + s.name + "ha sido cargada, se procede a mostrar el test");
        ShowTest();
    }

    private void OnSceneUnloaded(Scene s)
    {
        Debug.Log("La escena " + s.name + "está siendo descargada, se procede a mostrar el test");
        ShowTest();
    }

    public void ShowTest()
    {
        previousTimeScale = Time.timeScale;
        Debug.Log("mostrando test...");
        Time.timeScale = 0f;
        GURCanvas.SetActive(true);
    }

    public void EndTest()
    {
        Time.timeScale = previousTimeScale;
        GURCanvas.SetActive(false);
    }

}
