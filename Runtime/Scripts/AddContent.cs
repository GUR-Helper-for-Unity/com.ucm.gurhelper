using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script para añadir al Scroll View el contenido del panel, según la prueba que sea.
/// </summary>
public class AddContent : MonoBehaviour
{
    private ScrollRect scrollRect;
    private RectTransform viewport;
    [SerializeField]
    private GameObject pruebaPrefab;
    private GameObject testInstance;
    float previousTimeScale = 1f;

    /// <summary>
    /// Usamos Awake para poder catchear los componentes antes de que se llame a OnEnable
    /// </summary>
    void Awake()
    {

        scrollRect = GetComponent<ScrollRect>();
        viewport = scrollRect.viewport;
        previousTimeScale = Time.timeScale;
    }
    /// <summary>
    /// Usamos OnEnable y OnDisable porque el Canvas aparecerá y desaparecerá cuando sea necesario.
    /// </summary>
    private void OnEnable()
    {
        Time.timeScale = 0f;
        //instanciamos la prueba correspondiente
        testInstance = Instantiate<GameObject>(pruebaPrefab, viewport.gameObject.transform);
        scrollRect.content = testInstance.GetComponent<RectTransform>();
        testInstance.GetComponent<Pagination>().scrollRect = scrollRect;
    }
    private void OnDisable()
    {
        Time.timeScale = previousTimeScale;
        Destroy(testInstance);
    }
}
