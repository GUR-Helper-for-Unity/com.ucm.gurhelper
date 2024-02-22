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
        private int[] answers;
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
            for (int i = 0; i < answers.Length; i++)
            {
                _respuesta += i + " ("+ answers[i] + ") ";
                Test.Instance.UpdateRespuesta(numero, _respuesta);
            }
        }
        private void Awake()
        {
            setGlobalNumber();
        }
        private void Start()
        {
            enunciadoDisplayText.text = _enunciado;
            optionsDisplayText.text = string.Join(" ", Enumerable.Range(0, maxOptions + 1));
            answers = new int[questions.Length];
            for (int i = 0; i < questions.Length; i++)
            {
                GameObject childObj = Instantiate<GameObject>(simpleSliderPrefab, transform, true);
                SimpleSliderQuestion simpleslider = childObj.GetComponent<SimpleSliderQuestion>();
                sliders.Add(simpleslider);
                simpleslider.InitFromGroup(this, maxOptions, questions[i], i);
                answers[i] = -1;
            }
            Interpret();
        }

        public void updateAnswer(int simpleSlider, int answer)
        {
            answers[simpleSlider] = answer;
            Interpret();
        }
    }



}

