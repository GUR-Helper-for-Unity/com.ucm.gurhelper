using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class SessionEndEvent : GUREvent
    {
        public SessionEndEvent()
        {
            setTipo(eventType.SESSION_END); nombre = tipo.ToString();
        }
    }
}
