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
        public string Serialize(int questionID, string answer)
        {
            return "{" +
                "\"questionID\":\"" + questionID.ToString() + "\"" + ',' +
                "\"answer\":\"" + answer + "\"" +
                "}";
        }

        public string getExtension()
        {
            return ".json";
        }
    }
}
