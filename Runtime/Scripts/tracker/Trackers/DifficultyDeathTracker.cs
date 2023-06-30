using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    public class DifficultyDeathTracker : ITracker
    {
        private static DifficultyDeathTracker instance;
        public DifficultyDeathTracker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DifficultyDeathTracker();
                }
                return instance;
            }
        }

        public List<Persistence> persistences { get => ((ITracker)instance).persistences; set => ((ITracker)instance).persistences = value; }
        //------------------------------EVENTOS ASOCIADOS A ESTA PRUEBA-------------------------------------
        //ejemplos basura
        public DeathEvent Death()
        {
            return new DeathEvent();
        }
        public JumpEvent Jump()
        {
            return new JumpEvent();
        }
        public CollisionEvent Collision()
        {
            return new CollisionEvent();
        }
        public PlayerPosEvent PlayerPosition()
        {
            return new PlayerPosEvent();
        }

    }

}

