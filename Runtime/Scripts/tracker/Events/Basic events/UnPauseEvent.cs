using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class UnPauseEvent : Event
    {
        public UnPauseEvent()
        {
            tipo = eventType.UNPAUSE;
            nombre = tipo.ToString();

        }
    }
}
