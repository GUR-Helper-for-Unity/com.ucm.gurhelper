using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    public interface ITracker
    {
        List<Persistence> persistences { get; set; }
        public static ITracker Instance { get; }

        public void AddPersistence(Persistence p) { persistences.Add(p); }
        public void TrackSynchroEvent(Event e)
        { 
            //Debug.Log(e.name);
            foreach (Persistence persistence in persistences)
            {
                persistence.Send(e);
            }
        }
    }
}