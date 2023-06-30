using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class CollisionEvent : Event
    {
        public int id;

        public CollisionEvent()
        {
            tipo = eventType.COLLISION;
            nombre = tipo.ToString();

        }

        public CollisionEvent Id(int identificador)
        {
            id = identificador;
            return this;
        }
    }
}
