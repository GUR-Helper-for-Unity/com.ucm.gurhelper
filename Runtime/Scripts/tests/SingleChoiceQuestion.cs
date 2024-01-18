using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;
using UnityEngine.UIElements;
using System;

namespace GURHelper
{
    public class SingleChoiceQuestion : Question
    {
        [SerializeField]
        private TMP_Text enunciadoDisplayText;
        [SerializeField]
        ToggleGroup questionsDisplayToggle;
        [SerializeField]
        string[] opciones;
        //TO DO Crear un resources dictionary
        [SerializeField]
        GameObject togglePrefabUI;

        public override string Interpret()
        {
            var toggleActiveText = questionsDisplayToggle.GetFirstActiveToggle();
            var a = toggleActiveText.GetComponentInChildren<Text>().text;
            int opcionIndex = Array.IndexOf(opciones, toggleActiveText);

            return '\n' + numero.ToString() + ": " + _enunciado + '\n' + "ANS - " + opcionIndex.ToString() + ": " + toggleActiveText;
        }
        private void Update()
        {
            Debug.Log(questionsDisplayToggle.GetFirstActiveToggle().GetComponentInChildren<Text>().text);
        }

        private void Start()
        {
            enunciadoDisplayText.text = _enunciado;
            for (int i = 0; i < opciones.Length; i++)
            {
                GameObject childObj = Instantiate<GameObject>(togglePrefabUI, questionsDisplayToggle.transform, true);
                questionsDisplayToggle.RegisterToggle(childObj.GetComponent<UnityEngine.UI.Toggle>());
                childObj.GetComponent<UnityEngine.UI.Toggle>().group = questionsDisplayToggle;
                Text t = childObj.GetComponentInChildren<Text>();
                t.text = opciones[i];
            }
        }

    }
}

