using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class TestEndEvent : Event
    {
        public TestEndEvent()
        {
            setTipo(eventType.TEST_END);
            nombre = tipo.ToString();

        }
    }
}
