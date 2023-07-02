using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class LevelStartEvent : Event
    {
        //Guarda el indice de la escena en la que ocurre
        public int nivel;
        public LevelStartEvent()
        {
            setTipo(eventType.LEVEL_START);
            nombre = tipo.ToString();

        }

        public LevelStartEvent Nivel(int n)
        {
            nivel = n;
            return this;
        }

    }
}
