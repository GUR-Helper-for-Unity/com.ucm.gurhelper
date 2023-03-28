using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GURManager))]
public class GURManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GURManager manager = (GURManager)target;

        DrawDefaultInspector();
#if UNITY_EDITOR
        if (manager.showMinutes)
        {
            manager.minutes = EditorGUILayout.FloatField("Minutes", manager.minutes);
        }
#endif

        
    }
}
