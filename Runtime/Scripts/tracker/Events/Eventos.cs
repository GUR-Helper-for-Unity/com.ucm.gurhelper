using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public abstract class Event
    {
        public eventType tipo;
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

