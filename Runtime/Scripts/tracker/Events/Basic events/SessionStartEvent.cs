using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class SessionStartEvent : Event
    {
        public SessionStartEvent()
        {
            tipo = eventType.SESSION_START; nombre = tipo.ToString();
        }
    }
}
