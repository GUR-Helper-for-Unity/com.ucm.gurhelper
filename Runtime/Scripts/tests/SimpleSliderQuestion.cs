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
    public class SimpleSliderQuestion : Question
    {
        [SerializeField]
        private TMP_Text enunciadoDisplayText;
        [SerializeField]
        private int maxOptions = 5;
        [SerializeField]
        private TMP_Text optionsDisplayText;
        private float selectedOption = 0;
        public bool isSingle = false;
        private MultipleSliderQuestion father;
        public override void Interpret()
        {
            _respuesta = selectedOption.ToString();
            if (isSingle)
            {
                Test.Instance.UpdateRespuesta(numero, _respuesta);
            }
        }
        private void Awake()
        {
            if(isSingle)
                setGlobalNumber();
        }
        private void Start()
        {
            enunciadoDisplayText.text = _enunciado;
            optionsDisplayText.text = string.Join(" ", Enumerable.Range(0, maxOptions+1));
            optionsDisplayText.gameObject.SetActive(isSingle);
            UnityEngine.UI.Slider slider = GetComponentInChildren<UnityEngine.UI.Slider>(true);
            slider.maxValue = maxOptions;
            slider.value = selectedOption;
            slider.onValueChanged.AddListener(delegate { ToggleValueChanged(slider); });
            Interpret();
        }
        void ToggleValueChanged(UnityEngine.UI.Slider changed)
        {
            if (father == null)
            {
                selectedOption = changed.value;
                Interpret();
            }
            else
            {
                selectedOption = changed.value;
                father.updateAnswer(_numero, (int)selectedOption);
            }
        }

        public void InitFromGroup(MultipleSliderQuestion ms, int numOps, string enunciado, int numPregunta)
        {
            father = ms;
            isSingle = false;
            _enunciado = enunciado;
            _numero = numPregunta;
            maxOptions = numOps;
        }

    }



}

