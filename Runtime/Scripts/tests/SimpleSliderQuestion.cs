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
        private bool isSingle = true;
        public override void Interpret()
        {
            _respuesta = selectedOption.ToString();
            if (isSingle)
            {
                Test.Instance.UpdateRespuesta(numero, _respuesta);
            }
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
            selectedOption = changed.value;
            Interpret();
        }

        public void InitFromGroup(int numOps, string enunciado, int numPregunta)
        {
            isSingle = false;
            _enunciado = enunciado;
            _numero = numPregunta;
            maxOptions = numOps;
        }

    }



}

