using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// enum para diferenciar las diferentes ventanas por las que 
/// dividimos el men� de creaci�n de un nuevo test
/// </summary>
public enum MENUPAGE
{
    WELCOME, NAME, UBERQUESTION, CONFIGTEST, TAGS, END
}

public class NewTest : EditorWindow
{
    //rects que sirven para separar en secciones la ventana
    Rect header, page, bottom;
    //texturas de prueba para tener un color de fondo en las secciones
    Texture2D headerT, pageT;

    MENUPAGE actualState;

    /// <summary>
    /// M�todo de unity para abrir la ventana
    ///la linea del MenuItem siempre tiene que estar en la linea de encima de OpenWindow
    /// </summary>
    [MenuItem("Window/GUR Helper/New Test")]
    static void OpenWindow()
    {
        NewTest window = (NewTest)GetWindow(typeof(NewTest));
        window.minSize = new UnityEngine.Vector2(600, 300);
        window.Show();
    }


    /// <summary>
    /// m�todo de Unity
    /// metodo similar a start/awake
    /// </summary>
    private void OnEnable()
    {
        //inicializamos texturas de color plano
        headerT = new Texture2D(1, 1);
        headerT.SetPixel(0, 0, new Color(0.3f,0.7f,0.3f,1));
        headerT.Apply();

        pageT = new Texture2D(1, 1);
        pageT.SetPixel(0, 0, Color.grey);
        pageT.Apply();
    }

    /// <summary>
    /// metodo de Unity
    /// update, pero se llama una vez por interaccion con la ventana, no por frame
    /// </summary>
    private void OnGUI()
    {
        DefineRects();
        DrawHeader();
        DrawPage();
        DrawBottom();
    }
    /// <summary>
    /// Define el tama�o de los rects de la ventana, se llama en cada interacci�n debido a los posibles cambios de tama�o de ventana
    /// </summary>
    private void DefineRects()
    {
        /*algo como esto:
         * header
         * 
         * page
         * 
         * bottom
         */

        header.x = 0; header.y = 0; header.width = Screen.width; header.height = Screen.height / 5;
        page.x = 0; page.y = header.height; page.width = Screen.width; page.height = Screen.height / 2;
        bottom.x = 0; bottom.y = page.y+page.height; bottom.width = Screen.width; bottom.height = Screen.height / 5;

        //dibujamos las texturas
        GUI.DrawTexture(header, headerT);
        GUI.DrawTexture(page, pageT);
        GUI.DrawTexture(bottom, headerT);
    }

    /// <summary>
    /// m�todo de renderizado de la zona de encabezado de la ventana
    /// </summary>
    private void DrawHeader()
    {
        GUILayout.BeginArea(header);
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("P�gina actual: ");
                GUILayout.Label(actualState.ToString());
            EditorGUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
    /// <summary>
    /// m�todo que elige qu� debe renderizar en la zona de la p�gina en la ventana
    /// </summary>
    private void DrawPage()
    {
        GUILayout.BeginArea(page);
        //elegimos qu� dibujar seg�n la p�gina
            switch (actualState)
            {
                case MENUPAGE.WELCOME:
                    welcomePage();
                    break;
                case MENUPAGE.NAME:
                    GUILayout.Label("this is the name page...");
                    break;
                case MENUPAGE.UBERQUESTION:
                    GUILayout.Label("this is the question page...");
                    break;
                case MENUPAGE.CONFIGTEST:
                    GUILayout.Label("this is the config test page...");
                    break;
                case MENUPAGE.TAGS:
                        GUILayout.Label("this is the tags page...");
                        break;
                case MENUPAGE.END:
                    GUILayout.Label("this is the end page...");
                    break;
            }
        GUILayout.EndArea();
    }

    /// <summary>
    /// m�todo de renderizado del pie de p�gina de la ventana
    /// </summary>
    private void DrawBottom()
    {
        GUILayout.BeginArea(bottom);
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Cambiar de p�gina");
                if (GUILayout.Button("-->", GUILayout.Height(20), GUILayout.Width(50)))
                {
                    actualState++;
                    if (actualState == MENUPAGE.END) actualState = 0;
                }
            EditorGUILayout.EndHorizontal();
        GUILayout.EndArea();
       
    }
    /// <summary>
    /// m�todos de renderizado y l�gica de las diferentes p�ginas
    /// </summary>
    private void welcomePage()
    {
        GUILayout.Label("this is the welcome page");
    }
    //etc...

}
