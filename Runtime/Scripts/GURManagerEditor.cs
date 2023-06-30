using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace GURHelper
{
    [CustomEditor(typeof(GURManager))]
    public class GURManagerEditor : Editor
    {
        private SerializedProperty persistencesArrayProperty;
        private SerializedProperty serializersArrayProperty;

        private void OnEnable()
        {
            persistencesArrayProperty = serializedObject.FindProperty("persistences");
            serializersArrayProperty = serializedObject.FindProperty("serializers");
        }

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
            //persistences and serializers
            serializedObject.Update();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Persistence location:");

            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < persistencesArrayProperty.arraySize; i++)
            {
                SerializedProperty enumDataProperty = persistencesArrayProperty.GetArrayElementAtIndex(i);
                persistenceType enumValue = (persistenceType)i;
                EditorGUILayout.PropertyField(enumDataProperty, new GUIContent(enumValue.ToString()));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Serialization formats:");

            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < serializersArrayProperty.arraySize; i++)
            {
                SerializedProperty enumDataProperty = serializersArrayProperty.GetArrayElementAtIndex(i);
                serializerType enumValue = (serializerType)i;
                EditorGUILayout.PropertyField(enumDataProperty, new GUIContent(enumValue.ToString()));
            }
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();

        }
    }
}