using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    public interface Serializer
    {
        public string Serialize(GUREvent e);
        public string Serialize(int questionID, string answer);
        public string getExtension();
    }
}
