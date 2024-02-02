using UnityEditor;
using UnityEngine;

namespace GURHelper
{

    /// <summary>
    /// enum para diferenciar las diferentes ventanas por las que 
    /// dividimos el menú de creación de un nuevo test
    /// </summary>
    public enum MENUPAGE
    {
        WELCOME, FAQ, SELECTTEST, FINISH
    }

    public class NewTest : EditorWindow
    {
        //rects que sirven para separar en secciones la ventana
        Rect header, page, pageText,bottom;
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
            headerT.SetPixel(0, 0, new Color(0.3f, 0.7f, 0.3f, 1));
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
            page.x = 0; page.y = header.height; page.width = Screen.width; page.height = Screen.height * 5 / 8;
            pageText.x = 10; pageText.y = header.height; pageText.width = Screen.width-10; pageText.height = Screen.height * 5 / 8;
            bottom.x = 0; bottom.y = page.y + page.height; bottom.width = Screen.width; bottom.height = Screen.height / 4;

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
            GUILayout.BeginArea(pageText);
            //elegimos qué dibujar según la página
            switch (actualState)
            {
                case MENUPAGE.WELCOME:
                    welcomePage();
                    break;
                case MENUPAGE.FAQ:
                    FAQpage();
                    break;

                case MENUPAGE.SELECTTEST:
                    selectTestPage();
                    break;
                case MENUPAGE.FINISH:
                    finishPage();
                    break;
            }
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
                if (actualState == MENUPAGE.FINISH) actualState = 0;
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
                case MENUPAGE.FAQ:

                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("<--", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(50)))
                    {
                        actualState = MENUPAGE.WELCOME;
                    }
                    EditorGUILayout.EndHorizontal();
                    break;

                case MENUPAGE.SELECTTEST:

                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("<--", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(50)))
                    {
                        actualState = MENUPAGE.WELCOME;
                    }
                    EditorGUILayout.EndHorizontal();
                    break;

                case MENUPAGE.FINISH:


                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("<--", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(50)))
                    {
                        actualState = MENUPAGE.SELECTTEST;
                    }
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Inicio", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(50)))
                    {
                        actualState = MENUPAGE.WELCOME;
                    }
                    EditorGUILayout.EndHorizontal();
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
            EditorGUILayout.BeginVertical();

                EditorGUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Guía de usuario", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(300)))
                    {
                        actualState = MENUPAGE.FAQ;
                    }
                GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                 if (GUILayout.Button("Nueva Prueba", headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(300)))
                 {
                     actualState = MENUPAGE.SELECTTEST;

                 }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();





            EditorGUILayout.EndVertical();

        }

        public enum TESTTYPE
        {
            NONE, DIFFICULTYDEATH, END
        }
        int selectedButton = -1; TESTTYPE testType = TESTTYPE.NONE;
        string[] testNames = { " ", "Prueba para la dificultad con mecánica de muerte" };
        private void FAQpage()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true, headerS.GetStyle("horizontalScrollbar"), headerS.GetStyle("verticalScrollbar"));
            GUILayout.Label("Qué es y como usar la herramienta GUR Helper", headerS.GetStyle("Header"));
            GUILayout.Label("Esta herramienta se utiliza para integrar pruebas de usuario predefinidas a tu escena de Unity. Las pruebas de usuario se componen de dos elementos principales:\n" +
                "- Test con preguntas relacionadas con la prueba\n"+
                "- Tracker de eventos que ocurren en partida\n"+
                "Para utilizar la herramienta, ve a la pestaña principal y haz click en \"Nueva prueba\". Elige la prueba de usuario predefinida deseada y sigue los pasos indicados para integrarla en tu escena.", headerS.GetStyle("standardText"));
            GUILayout.Label("FAQ", headerS.GetStyle("Header"));
            GUILayout.Label("¿Qué es un tracker?", headerS.GetStyle("welcometext"));
            GUILayout.Label("lorem ipsum...", headerS.GetStyle("standardText"));
            GUILayout.Label("¿Dónde se guardan las respuestas del test? ¿Y los eventos recogidos?", headerS.GetStyle("welcometext"));
            GUILayout.Label("lorem ipsum...", headerS.GetStyle("standardText"));
            GUILayout.Label("...", headerS.GetStyle("welcometext"));
            GUILayout.Label("...", headerS.GetStyle("standardText"));
            // End the scrollview we began above.
            GUILayout.EndScrollView();


        }
        string[] descriptions = { " ",
    "this is the description for the difficulty death test"};
        Vector2 scrollPosition;

        private void selectTestPage()
        {
            EditorGUILayout.BeginVertical();
            GUILayout.FlexibleSpace();


            for (int i = 1; i < (int)TESTTYPE.END; i++)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(testNames[i], headerS.GetStyle("button"), GUILayout.Height(50), GUILayout.Width(500)))
                {
                    testType = (TESTTYPE)i;
                    actualState = MENUPAGE.FINISH;
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
                
            }
            GUILayout.FlexibleSpace();

            EditorGUILayout.EndVertical();


        }


        private void finishPage()
        {
            EditorGUILayout.BeginVertical();

            GUILayout.FlexibleSpace();
            GUILayout.Label("Para realizar esta prueba, añade los siguientes elementos a tu escena:\n", headerS.GetStyle("welcometext"));
            GUILayout.Label("- Packages/Game User Research Helper/Runtime/Prefabs/GURManager.prefab.\n Este objeto debe estar en la raíz de la escena que quieras utilizar como escena para realizar la prueba de usuario.\n", headerS.GetStyle("standardText"));
            GUILayout.Label("- Al objeto anterior, añade a la variable \"Test\" desde el inspector el objeto que se encuentra en Packages/Game User Research Helper/Runtime/Prefabs/Tests/Difficulty_Death/Difficulty_Death.prefab.\n", headerS.GetStyle("standardText"));
            GUILayout.Label("- Debe haber al menos un objeto en tu escena con el script Call Event asociado, con el tipo de evento \"DEATH\". Haz una llamada a ese evento en el momento que quieras contabilizar una muerte.\n", headerS.GetStyle("standardText"));
            GUILayout.Label("- Existe un objeto de ejemplo con dicho script en Packages/Game User Research Helper/Runtime/Prefabs/Tests/Difficulty_Death/CallDeathGO.prefab para añadirlo en tu escena.\n", headerS.GetStyle("standardText"));


            GUILayout.FlexibleSpace();

            EditorGUILayout.EndVertical();


        }
    }

}
