using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public enum TestTrigger
{
    TIME, ONLOAD, ONUNLOAD
}

public class GURManager : MonoBehaviour
{
    [Tooltip("Objeto que contiene el Canvas que se va a utilizar (prefab en la carpeta del package)")]
    public GameObject GURCanvas;
    [Tooltip("Elige cuando se va a activar la prueba.")]
    public TestTrigger triggerType;
    [HideInInspector]
    public float minutes;
    [HideInInspector]
    public bool showMinutes = false;

    bool inTest = false;

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
        ///en caso de que se quiera realizar la prueba cuando se cargue o se descargue la escena actual, 
        ///se añaden los comportamientos al SceneManager
        ///en caso de que se haga por tiempo, se realiza un Invoke con un tiempo de espera de x minutos.
        GURCanvas.SetActive(false);
        inTest = false;
        switch (triggerType)
        {
            case TestTrigger.TIME:
                Invoke("ShowTest", minutes * 60f);
                break;
            case TestTrigger.ONLOAD:
                SceneManager.sceneLoaded += OnSceneLoaded;
                break;
            case TestTrigger.ONUNLOAD:
                SceneManager.sceneUnloaded += OnSceneUnloaded;
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

    private void ShowTest()
    {
        Debug.Log("mostrando test...");
        GURCanvas.SetActive(true);
    }

}
