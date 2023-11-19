using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class SessionStartEvent : GUREvent
    {
        public SessionStartEvent()
        {
            setTipo(eventType.SESSION_START); nombre = tipo.ToString();
        }
    }
}
