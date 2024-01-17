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
    public class SingleChoiceQuestion : MonoBehaviour, IQuestion
    {
        [SerializeField]
        private string _enunciado;
        private int? _numero = null;
        [SerializeField]
        private TMP_Text enunciadoDisplayText;
        [SerializeField]
        ToggleGroup questionsDisplayToggle;
        [SerializeField]
        string[] opciones;
        //TO DO Crear un resources dictionary
        GameObject togglePrefabUI;

        public string enunciado { get => _enunciado; }
        public int? numero { get => _numero; }


        public string Interpret()
        {
            string toggleActiveText = questionsDisplayToggle.GetFirstActiveToggle().GetComponentInChildren<Text>().text;
            int opcionIndex = Array.IndexOf(opciones, toggleActiveText);

            string _respuesta = '\n' + numero.ToString() + ": " + _enunciado + '\n' + "ANS - " + opcionIndex.ToString() + ": " + toggleActiveText;

            return _respuesta;
        }


        private void Start()
        {
            enunciadoDisplayText.text = _enunciado;
            for (int i = 0; i < opciones.Length; i++)
            {
                GameObject childObj = Instantiate<GameObject>(togglePrefabUI, questionsDisplayToggle.transform, false);
                questionsDisplayToggle.RegisterToggle(childObj.GetComponent<UnityEngine.UI.Toggle>());
                Text t = childObj.GetComponentInChildren<Text>();
                t.text = opciones[i];
            }
            questionsDisplayToggle.SetAllTogglesOff();
        }

    }
}

