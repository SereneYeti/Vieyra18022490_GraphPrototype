using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Vieyra1802490_ParsingPrototype
{
    public class Items
    {
        public int key;
        public string name;
        public string discription;
        public GameObject gameObject;

        public override string ToString()
        {
            return name + ", " + discription + ", " + key;
        }
    }

}
