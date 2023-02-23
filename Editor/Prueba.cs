using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Prueba : EditorWindow
{
    [MenuItem("Window/Prueba")]
    static void OpenWindow()
    {
        Prueba window = (Prueba)GetWindow(typeof(Prueba));
        window.minSize = new UnityEngine.Vector2(600, 300);
        window.Show();
    }
}
