using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GURHelper
{
    [System.Serializable]
    public abstract class GUREvent
    {
        //getter privado explicito para evitar la serializaci�n de la variable publica
        public eventType tipo { get; private set; }
        public void setTipo(eventType t) { tipo = t; }
        /// <summary>
        /// usages es un array que indica los trackers a los que est� asociado este evento. El evento s�lo se enviar� si el tracker actual est� dentro del conjunto
        /// de trackers asociados al evento. Si est� vac�o, cualquier tracker puede implementarlo.
        /// </summary>
        public List<trackerType> conjunto { get; private set; }
        public string nombre;
        public float tiempo;
        public long sesion;
        public GUREvent()
        {
            tiempo = Time.realtimeSinceStartup;
            sesion = UnityEngine.Analytics.AnalyticsSessionInfo.sessionId;
            conjunto = new List<trackerType>();
        }
    }
}

