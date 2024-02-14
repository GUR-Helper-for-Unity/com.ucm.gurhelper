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
        public string Serialize(int questionID, string answer)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            binaryFormatter.Serialize(stream, questionID.ToString());
            binaryFormatter.Serialize(stream, answer);
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
