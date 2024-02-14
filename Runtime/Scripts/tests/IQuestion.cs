using UnityEngine;

namespace GURHelper
{
    public interface IQuestion
    {
        string enunciado { get; }
        int numero { get; }
        string respuesta { get; }

        /// <summary>
        /// </summary>
        public void Interpret();
    }


    public abstract class Question : MonoBehaviour, IQuestion
    {
        [SerializeField]
        protected string _enunciado;
        [SerializeField]
        protected int _numero = -1;
        protected static int questionCounter = 0;
        protected string _respuesta;
        public string enunciado { get => _enunciado; }
        public int numero { get => _numero; }
        public string respuesta { get =>  _respuesta; }

        public abstract void Interpret();
        private void Awake()
        {
            _numero = questionCounter++;
        }

    }
}

