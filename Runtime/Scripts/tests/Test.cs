using GURHelper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    public class Test : MonoBehaviour
    {
        public List<Question> myTest;
        public static Dictionary<int, string> respuestasTest { get; private set; }

        private static Test instance;
        public static Test Instance { get { return instance; } }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            respuestasTest = new Dictionary<int, string>();

        }

        public void UpdateRespuesta(int id, string respuesta)
        {
            respuestasTest[id] = respuesta;
        }


    }

}
