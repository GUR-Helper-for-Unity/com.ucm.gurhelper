using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public abstract class Event
    {
        public eventType tipo;
        /// <summary>
        /// usages es un array que indica los trackers a los que est� asociado este evento. El evento s�lo se enviar� si el tracker actual est� dentro del conjunto
        /// de trackers asociados al evento. Si est� vac�o, cualquier tracker puede implementarlo.
        /// </summary>
        public List<trackerType> conjunto;
        public string nombre;
        public float tiempo;
        public long sesion;
        public Event()
        {
            tiempo = Time.realtimeSinceStartup;
            sesion = UnityEngine.Analytics.AnalyticsSessionInfo.sessionId;
        }
    }
}

