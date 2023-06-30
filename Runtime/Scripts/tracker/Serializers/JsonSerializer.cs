using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Json;

namespace GURHelper
{
    public class JsonSerializer : Serializer
    {

        public string Serialize(Event e)
        {
            return JsonUtility.ToJson(e);
        }

        public string getExtension()
        {
            return ".json";
        }
    }
}
