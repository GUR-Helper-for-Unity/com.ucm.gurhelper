using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Json;

namespace GURHelper
{
    public class JsonSerializer : Serializer
    {

        public string Serialize(GUREvent e)
        {
            return JsonUtility.ToJson(e);
        }
        public string Serialize(Question q)
        {
            return JsonUtility.ToJson(q.Interpret());
        }

        public string getExtension()
        {
            return ".json";
        }
    }
}
