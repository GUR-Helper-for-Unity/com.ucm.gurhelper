using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class SessionEndEvent : Event
    {
        public SessionEndEvent()
        {
            tipo = eventType.SESSION_END; nombre = tipo.ToString();
        }
    }
}
