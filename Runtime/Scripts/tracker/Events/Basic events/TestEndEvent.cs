using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class TestEndEvent : GUREvent
    {
        public TestEndEvent()
        {
            setTipo(eventType.TEST_END);
            nombre = tipo.ToString();

        }
    }
}
