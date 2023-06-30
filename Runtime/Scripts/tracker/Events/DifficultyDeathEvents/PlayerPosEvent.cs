using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class PlayerPosEvent : Event
    {
        public float x;
        public float y;

        public PlayerPosEvent()
        {
            tipo = eventType.PLAYER_POSITION;
            nombre = tipo.ToString();

        }

        public PlayerPosEvent X(float X)
        {
            x = X;
            return this;
        }

        public PlayerPosEvent Y(float Y)
        {
            y = Y;
            return this;
        }
    }

}
