using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Homeworld : System.Attribute
    {
        //string name;
        public string city;
        public string name1;
        public int rulebook_version;

        public Homeworld(/*string name*/)
        {
            //this.name = name;
            city = "";
            rulebook_version = 0;
            name1 = "";
        }

        /*public string GetName()
        {
            return name;
        }*/
    }
}
