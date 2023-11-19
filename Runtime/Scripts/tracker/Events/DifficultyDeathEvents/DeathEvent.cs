using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class DeathEvent : GUREvent
    {
        public float x;
        public float y;
        public float z;

        public DeathEvent()
        {
            setTipo(eventType.DEATH);
            nombre = tipo.ToString();
            conjunto.Add(trackerType.DIFFICULTY_DEATHS);
        }

        public DeathEvent X(float X)
        {
            x = X;
            return this;
        }

        public DeathEvent Y(float Y)
        {
            y = Y;
            return this;
        }
        public DeathEvent Z(float Z)
        {
            z = Z;
            return this;
        }
    }
}
