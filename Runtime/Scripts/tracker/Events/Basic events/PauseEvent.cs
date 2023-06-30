using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class PauseEvent : Event
    {
        public PauseEvent()
        {
            tipo = eventType.PAUSE;
            nombre = tipo.ToString();

        }
    }
}
