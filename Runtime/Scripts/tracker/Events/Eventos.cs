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
        /// usages es un array que indica los trackers a los que está asociado este evento. El evento sólo se enviará si el tracker actual está dentro del conjunto
        /// de trackers asociados al evento. Si está vacío, cualquier tracker puede implementarlo.
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

