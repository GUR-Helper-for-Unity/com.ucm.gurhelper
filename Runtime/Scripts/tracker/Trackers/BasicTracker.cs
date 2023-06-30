using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    /// <summary>
    /// Tracker con la implementacion de los eventos básicos que siempre nos interesaría utilizar.
    /// </summary>
    public class BasicTracker : ITracker
    {
        private static BasicTracker instance;
        public static BasicTracker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BasicTracker();
                }
                return instance;
            }
        }

        public List<Persistence> persistences { get => ((ITracker)instance).persistences; set => ((ITracker)instance).persistences = value; }


        public SessionStartEvent SessionStart()
        {
            return new SessionStartEvent();
        }
        public SessionEndEvent SessionEnd()
        {
            return new SessionEndEvent();
        }
        public PauseEvent Pause()
        {
            return new PauseEvent();
        }
        public UnPauseEvent UnPause()
        {
            return new UnPauseEvent();
        }

    }
}
