using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class PauseEvent : GUREvent
    {
        public PauseEvent()
        {
            setTipo(eventType.PAUSE);
            nombre = tipo.ToString();

        }
    }
}
