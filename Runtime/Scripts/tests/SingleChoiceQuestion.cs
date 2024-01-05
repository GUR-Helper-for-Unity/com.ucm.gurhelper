using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;
using UnityEngine.UIElements;

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
        //mejorar el acceso a estos resources mediante codigo directamente, con un diccionario quizas?


        public string enunciado { get => _enunciado; }
        public int? numero { get => _numero; }


        public string Interpret()
        {
            string _respuesta = "";

            return _respuesta;
        }


        private void Start()
        {
            enunciadoDisplayText.text = _enunciado;
            for(int i = 0; i < opciones.Length; i++)
            {
               // Instantiate<>
            }
        }

    }
}

