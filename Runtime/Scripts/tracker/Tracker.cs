using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GURHelper
{
    public class Tracker
    {
        public trackerType type { get; set; }
        public bool isDirectoryOn { get; set; } = false;

        public Tracker() { type = trackerType.BASIC; }
        private static Tracker instance;
        public static Tracker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Tracker();
                    instance.persistences = new List<Persistence>();
                }
                return instance;
            }
        }
        List<Persistence> persistences { get; set; }
        public void AddPersistence(Persistence p) { persistences.Add(p); Debug.Log("Added persistance: " + p.GetType().Name); }
        public void TrackSynchroEvent(GUREvent e)
        {
            Debug.Log(e.nombre);
            if (!CheckUsage(e) || persistences.Count == 0)
                return;
            foreach (Persistence persistence in persistences)
            {
                persistence.Send(e);
            }
        }
        public void TrackTest(Dictionary<int, string> myTest)
        {
            foreach (Persistence persistence in persistences)
            {
                foreach (var q in myTest)
                {
                    persistence.Send(q.Key, q.Value);
                }
            }
        }
        private bool CheckUsage(GUREvent e)
        {
            //caso base: usable en cualquier tracker
            if (e.conjunto.Count == 0)
                return true;
            //resto de casos: debe contener el tipo actual de tracker en el conjunto
            if (e.conjunto.Any(item => item == type))
                return true;
            //error: no se puede enviar este tipo de evento.
            Debug.LogError("This tracker (type: {type}) cannot track an event of type: " + e.tipo);
            return false;
        }

        //------------------------------ALL EVENTS----------------------------------------
        #region BASIC EVENTS
        public SessionStartEvent SessionStart()
        {
            return new SessionStartEvent();
        }
        public SessionEndEvent SessionEnd()
        {
            return new SessionEndEvent();
        }
        public TestStartedEvent TestStarted()
        {
            return new TestStartedEvent();
        }
        public TestEndEvent TestEnd()
        {
            return new TestEndEvent();
        }
        public PauseEvent Pause()
        {
            return new PauseEvent();
        }
        public UnPauseEvent UnPause()
        {
            return new UnPauseEvent();
        }
        public LevelStartEvent LevelStart()
        {
            return new LevelStartEvent();
        }
        public LevelEndEvent LevelEnd()
        {
            return new LevelEndEvent();
        }
        #endregion

        #region DIFFICULTY_DEATHS
        public DeathEvent Death()
        {
            return new DeathEvent();
        }
        public PlayerPosEvent PlayerPosition()
        {
            return new PlayerPosEvent();
        }
        #endregion

    }
}