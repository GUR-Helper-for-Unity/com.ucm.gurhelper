using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    [System.Serializable]
    public class LevelEndEvent : Event
    {
        public enum LEVEL_STATUS { SUCCESS,LOSE,MATCH,QUIT,NONE}
        public int nivel;
        public LEVEL_STATUS completition;

        public LevelEndEvent()
        {
            setTipo(eventType.LEVEL_END);
            nombre = tipo.ToString();
        }
        public LevelEndEvent Nivel(int n)
        {
            nivel = n;
            return this;
        }
        public LevelEndEvent Completition(LEVEL_STATUS c)
        {
            completition = c;
            return this;
        }
    }
}
