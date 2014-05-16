using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintAuthorInfo(typeof(Imperium));
            //PrintAuthorInfo(typeof(DarkEldar));
            DarkEldar de = new DarkEldar();
            de.Attr();
            Console.ReadKey();
        }

        /*public static void PrintAuthorInfo(System.Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.

            // Displaying output.
            foreach (System.Attribute attr in attrs)
            {
                if (attr is Homeworld)
                {
                    Homeworld h = (Homeworld)attr;
                    System.Console.WriteLine("   {0}, version {1}", h.GetName(), h.rulebook_version);
                }
            }
        }*/
    }
}
