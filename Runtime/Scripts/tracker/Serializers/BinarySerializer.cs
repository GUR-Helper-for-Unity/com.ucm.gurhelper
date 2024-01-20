using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace GURHelper
{
    public class BinarySerializer : Serializer
    {
        public string Serialize(GUREvent e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            binaryFormatter.Serialize(stream, e);
            stream.Position = 0;

            StreamReader reader = new StreamReader(stream);
            string s = reader.ReadToEnd();

            return s;
        }
        public string Serialize(Question q)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            q.Interpret();
            binaryFormatter.Serialize(stream, q.numero.ToString());
            binaryFormatter.Serialize(stream, q.enunciado.ToString());
            binaryFormatter.Serialize(stream, q.respuesta.ToString());
            stream.Position = 0;

            StreamReader reader = new StreamReader(stream);
            string s = reader.ReadToEnd();

            return s;
        }

        public string getExtension()
        {
            return ".bin";
        }

    }
}
