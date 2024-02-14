using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;
using UnityEngine.UIElements;
using System;
using System.Linq;

namespace GURHelper
{
    public class MultipleSliderQuestion : Question
    {
        [SerializeField]
        private TMP_Text enunciadoDisplayText;
        [SerializeField]
        private int maxOptions = 5;
        [SerializeField]
        private TMP_Text optionsDisplayText;
        [SerializeField]
        string[] questions;
        [SerializeField]
        GameObject simpleSliderPrefab;
        private List<SimpleSliderQuestion> sliders = new List<SimpleSliderQuestion>();
        public override void Interpret()
        {
            _respuesta = "";
            for (int i = 0; i < sliders.Count; i++)
            {
                sliders[i].Interpret();
                _respuesta += i + " ("+ sliders[i].respuesta + ") ";
                Test.Instance.UpdateRespuesta(numero, _respuesta);
            }
        }

        private void Start()
        {
            enunciadoDisplayText.text = _enunciado;
            optionsDisplayText.text = string.Join(" ", Enumerable.Range(0, maxOptions + 1));

            for (int i = 0; i < questions.Length; i++)
            {
                GameObject childObj = Instantiate<GameObject>(simpleSliderPrefab, transform, true);
                SimpleSliderQuestion simpleslider = childObj.GetComponent<SimpleSliderQuestion>();
                sliders.Add(simpleslider);
                simpleslider.InitFromGroup(maxOptions, questions[i], _numero);
            }
            Interpret();
        }
    }



}

