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
        private string selectedOption = "";

        public override void Interpret()
        {
            int opcionIndex = Array.IndexOf(opciones, selectedOption);
            _respuesta = opcionIndex.ToString() + ":" + selectedOption;
            Test.Instance.UpdateRespuesta(numero, _respuesta);

        }
        private void Awake()
        {
            setGlobalNumber();
        }
        private void Start()
        {
            enunciadoDisplayText.text = _enunciado;
            for (int i = 0; i < opciones.Length; i++)
            {
                GameObject childObj = Instantiate<GameObject>(togglePrefabUI, questionsDisplayToggle.transform, true);
                UnityEngine.UI.Toggle tog = childObj.GetComponent<UnityEngine.UI.Toggle>();
                Text t = childObj.GetComponentInChildren<Text>();
                tog.onValueChanged.AddListener(delegate { ToggleValueChanged(tog); });
                questionsDisplayToggle.RegisterToggle(tog);
                childObj.GetComponent<UnityEngine.UI.Toggle>().group = questionsDisplayToggle;
                t.text = opciones[i];
            }
            Interpret();
        }
        void ToggleValueChanged(UnityEngine.UI.Toggle clicked)
        {
            Text t = clicked.GetComponentInChildren<Text>();
            selectedOption = t.text;
            Interpret();
        }
    }

    

}

