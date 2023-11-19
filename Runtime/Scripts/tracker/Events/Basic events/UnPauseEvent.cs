using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class UnPauseEvent : GUREvent
    {
        public UnPauseEvent()
        {
            setTipo(eventType.UNPAUSE);
            nombre = tipo.ToString();

        }
    }
}
