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
            q.Interpret();
            string answer = q.respuesta;
            return "{" +
                "\"questionID\":\"" + q.numero.ToString() + "\"" + ',' +
                "\"questionText\":\"" + q.enunciado + "\"" + ',' +
                "\"answer\":\"" + answer + "\"" +
                "}";
        }

        public string getExtension()
        {
            return ".json";
        }
    }
}
