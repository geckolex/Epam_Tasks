using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Homeworld : System.Attribute
    {
        string name;
        public int rulebook_version;

        public Homeworld(string name)
        {
            this.name = name;
            rulebook_version = 0;
        }

        public string GetName()
        {
            return name;
        }
    }
}
