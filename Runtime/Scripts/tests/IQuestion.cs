using UnityEngine;

namespace GURHelper
{
    public interface IQuestion
    {
        string enunciado { get; }
        int? numero { get; }
        string respuesta { get; }

        /// <summary>
        /// Método que traduce lo que se encuentre en la UI a un string que contiene la pregunta y la respuesta asociada a este objeto.
        /// </summary>
        public string Interpret();
        /// <summary>
        /// Le envía al Tracker la respuesta de la pregunta para su serialización y persistencia.
        /// </summary>
        public void TrackQuestion();
    }


    public abstract class Question : MonoBehaviour, IQuestion
    {
        [SerializeField]
        protected string _enunciado;
        [SerializeField]
        protected int? _numero = null;
        protected string _respuesta;
        public string enunciado { get => _enunciado; }
        public int? numero { get => _numero; }
        public string respuesta { get =>  _respuesta; }

        public abstract string Interpret();

        public void TrackQuestion()
        {
            _respuesta = Interpret();
            //Tracker.Instance.TrackSynchroEvent(Tracker.Instance.Question).answer = _respuesta;
        }
    }
}

