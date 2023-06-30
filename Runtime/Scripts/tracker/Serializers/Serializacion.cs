using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GURHelper
{
    public interface Serializer
    {
        public string Serialize(Event e);
        public string getExtension();
    }
}
