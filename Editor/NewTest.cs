using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// enum para diferenciar las diferentes ventanas por las que 
/// dividimos el menú de creación de un nuevo test
/// </summary>
public enum MENUPAGE
{
    WELCOME, UBERQUESTION, CONFIGTEST, TAGS, END
}

public class NewTest : EditorWindow
{
    //rects que sirven para separar en secciones la ventana
    Rect header, page, bottom;
    //texturas de prueba para tener un color de fondo en las secciones
    Texture2D headerT, pageT;
    GUISkin headerS;

    MENUPAGE actualState;

    /// <summary>
    /// Método de unity para abrir la ventana
    ///la linea del MenuItem siempre tiene que estar en la linea de encima de OpenWindow
    /// </summary>
    [MenuItem("Window/GUR Helper/New Test")]
    static void OpenWindow()
    {
        NewTest window = (NewTest)GetWindow(typeof(NewTest));
        window.minSize = new UnityEngine.Vector2(1000, 600);
        window.Show();
    }


    /// <summary>
    /// método de Unity
    /// metodo similar a start/awake
    /// </summary>
    private void OnEnable()
    {
        headerS = Resources.Load<GUISkin>("Styles/Main");
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
    /// Define el tamaño de los rects de la ventana, se llama en cada interacción debido a los posibles cambios de tamaño de ventana
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

        header.x = 0; header.y = 0; header.width = Screen.width; header.height = Screen.height / 8;
        page.x = 0; page.y = header.height; page.width = Screen.width; page.height = Screen.height *5 /8;
        bottom.x = 0; bottom.y = page.y+page.height; bottom.width = Screen.width; bottom.height = Screen.height / 4;

        //dibujamos las texturas
        GUI.DrawTexture(header, headerT);
        GUI.DrawTexture(page, pageT);
        GUI.DrawTexture(bottom, headerT);
    }

    /// <summary>
    /// método de renderizado de la zona de encabezado de la ventana
    /// </summary>
    private void DrawHeader()
    {
        GUILayout.BeginArea(header);
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("GAME USER RESEARCH HELPER TOOL", headerS.GetStyle("Header"));
            EditorGUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
    /// <summary>
    /// método que elige qué debe renderizar en la zona de la página en la ventana
    /// </summary>
    private void DrawPage()
    {
        GUILayout.BeginArea(page);
        //elegimos qué dibujar según la página
            switch (actualState)
            {
                case MENUPAGE.WELCOME:
                    welcomePage();
                    break;
                case MENUPAGE.UBERQUESTION:
                    uberQuestion();
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
        drawNavigation();
        GUILayout.EndArea();
    }

    void drawNavigation()
    {
        EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("<--", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(50)))
            {
                if (actualState != MENUPAGE.WELCOME) actualState--;
            }
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("-->", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(50)))
            {
                actualState++;
                if (actualState == MENUPAGE.END) actualState = 0;
            }
        EditorGUILayout.EndHorizontal();
    }

    /// <summary>
    /// método de renderizado del pie de página de la ventana
    /// </summary>
    private void DrawBottom()
    {
        GUILayout.BeginArea(bottom);
        switch (actualState)
        {
            case MENUPAGE.UBERQUESTION:
                drawDescription();
                break;
            default:
                break;
        }
        GUILayout.EndArea();
       
    }
    /// <summary>
    /// métodos de renderizado y lógica de las diferentes páginas
    /// </summary>
    private void welcomePage()
    {
        GUILayout.Label("WELCOME TO THE GAME USER RESEARCH HELPER TOOL FOR UNITY.", headerS.GetStyle("Header"));
        GUILayout.Label("Use this tool to create different user tests for your project.", headerS.GetStyle("welcomeText"));
        GUILayout.Label("Click on the continue button to start creating a new user test.", headerS.GetStyle("welcomeText"));

    }

    int selectedButton = -1;
    string[] selStrings = { " ", " ", " ", " "};
    private void uberQuestion()
    {
        GUILayout.BeginVertical();
            GUILayout.Label("Selecciona el tipo de prueba que quieres realizar:", headerS.GetStyle("Header"));
            GUILayout.FlexibleSpace();
            selectedButton = GUILayout.SelectionGrid(selectedButton, selStrings, 1);
            GUILayout.FlexibleSpace();
        GUILayout.EndVertical();


    }
    string[] descriptions = { " ",
    "this is the description for the usability test.",
    "this is the description for the apreciation/ test."}
    private void drawDescription()
    {

    }

}
