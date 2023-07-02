using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{   
    /// <summary>
    /// Enum que guarda todos los tipos de eventos que existen. Es un enum que comparten todos los objetos que hereden de Event, para identificarse.
    /// </summary>
    public enum eventType { 
        //BASIC EVENTS
        SESSION_START, SESSION_END, TEST_START, TEST_END, LEVEL_START, LEVEL_END, PAUSE, UNPAUSE,
        //DIFFICULTY DEATH TEST RELATED
        DEATH, PLAYER_POSITION, 
        //END
        NULL
    }

    /// <summary>
    /// Enum que guarda los tipos de trackers que existen. Si una prueba necesita eventos asociados, se crea un tracker nuevo y un tipo enumerable para identificarlo.
    /// </summary>
    public enum trackerType
    {
        BASIC,DIFFICULTY_DEATHS,
        //END
        NULL
    }

    /// <summary>
    /// tipos de sistemas de persistencia que se han implementado
    /// </summary>
    public enum persistenceType
    {
        FILE, SERVER,
        //END
        NULL
    }

    /// <summary>
    /// tipos de serializacion que se han implementado
    /// </summary>
    public enum serializerType
    {
        JSON, BINARY,
        //END
        NULL
    }
}

