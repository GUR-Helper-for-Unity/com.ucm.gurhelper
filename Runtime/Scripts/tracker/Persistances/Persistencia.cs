using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Concurrent;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace GURHelper
{
    //sistema de persistencia síncrono
    public abstract class Persistence
    {
        public enum P_TYPES { LOCAL, SERVER}
        public Persistence(Serializer s)
        {
            serializer = s;
            Debug.Log("Added serializer: " + s.GetType().Name);
        }
        public abstract void Send(Event e);
        public void PersistThread()
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (!exit)
            {
                var time = sw.Elapsed;

                if (time.TotalMilliseconds >= elapsedTime + milisecondsToPersist)
                {
                    Persist();
                    elapsedTime = time.TotalMilliseconds;
                }

            }
            Persist();
            _streamWriter.Close();
        }
        public abstract void Persist();
        protected Serializer serializer;
        protected ConcurrentQueue<string> cola;
        protected StreamWriter _streamWriter;
        protected long sesion;
        protected double milisecondsToPersist = 1000;
        protected double elapsedTime = 0;
        public bool exit = false;   // bool es atomic en c#
    }
}
