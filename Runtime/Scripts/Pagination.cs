using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pagination : MonoBehaviour
{
    [HideInInspector]
    public ScrollRect scrollRect;
    [SerializeField]
    Button previousPage;
    [SerializeField]
    Button nextPage;
    [SerializeField]
    List<RectTransform> pages = new List<RectTransform>();

    int actualPage = 0;
    private void Awake()
    {
        previousPage.gameObject.SetActive(false);
        nextPage.gameObject.SetActive(false);
        //si hay mas de una pagina
        if (actualPage < pages.Count - 1) nextPage.gameObject.SetActive(true);

        //activa la primera pagina
        if(pages.Count >0)
        {
            foreach (RectTransform page in pages) page.gameObject.SetActive(false);
            pages[0].gameObject.SetActive(true);
        }  
    }

    /// <summary>
    /// M�todo que se llama cuando se pulsa el bot�n de avanzar p�gina
    /// </summary>
    public void goToNextPage()
    {
        //desactiva la pagina en la que se encuentra
        pages[actualPage].gameObject.SetActive(false);
        actualPage++;
        pages[actualPage].gameObject.SetActive(true);
        //si ha llegado a la ultima pagina, desactiva el boton de avanzar
        if (actualPage == pages.Count - 1) nextPage.gameObject.SetActive(false);
        //activa el bot�n para volver a la p�gina anterior
        if (!previousPage.gameObject.activeSelf) previousPage.gameObject.SetActive(true);

        scrollRect.verticalScrollbar.value = 1;
    }

    /// <summary>
    /// M�todo que se llama cuando se pulsa el bot�n de volver a la anterior p�gina
    /// </summary>
    public void goToPreviousPage()
    {
        //desactiva la pagina en la que se encuentra
        pages[actualPage].gameObject.SetActive(false);
        actualPage--;
        pages[actualPage].gameObject.SetActive(true);
        //si ha llegado a la primera pagina, desactiva el boton de ir hacia atr�s
        if (actualPage == 0) previousPage.gameObject.SetActive(false);
        //activa el bot�n para avanzar a la siguiente pagina
        if (!nextPage.gameObject.activeSelf) nextPage.gameObject.SetActive(true);

        scrollRect.verticalScrollbar.value = 1;

    }
}
