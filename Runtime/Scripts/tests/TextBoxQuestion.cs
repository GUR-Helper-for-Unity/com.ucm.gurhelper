using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace GURHelper
{
    public class TextBoxQuestion : Question
    {
        [SerializeField]
        private TMP_Text enunciadoDisplayText;

        private TMP_InputField answerField;

        public override void Interpret()
        {
            Test.Instance.UpdateRespuesta(numero, _respuesta);
        }

        private void Awake()
        {
            setGlobalNumber();
        }
        private void Start()
        {
            answerField = GetComponentInChildren<TMP_InputField>();
            Interpret();
        }

        public void saveText()
        {
            _respuesta = answerField.text;
            Interpret();
        }
    }



}

