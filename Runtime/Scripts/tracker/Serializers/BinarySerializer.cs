using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace GURHelper
{
    public class BinarySerializer : Serializer
    {
        public string Serialize(Event e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            binaryFormatter.Serialize(stream, e);
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
