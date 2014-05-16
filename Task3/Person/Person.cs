using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3 
{
    [Attribut(TableName = "Accessor")]
    class Person
    {
        [Attribut(Colum1 = "NAME")]
        public string name = "";
        
        [Attribut(Colum2 = "VALUE")]
        public string value = "";
    }
}
