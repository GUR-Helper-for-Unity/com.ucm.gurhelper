using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class TestStartedEvent : GUREvent
    {
        public TestStartedEvent()
        {
            setTipo(eventType.TEST_START);
            nombre = tipo.ToString();

        }
    }
}
