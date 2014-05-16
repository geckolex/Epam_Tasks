using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Task1
{
    [Homeworld(city = "Commorragh", rulebook_version = 5, name1 = "Accessor")]
    class DarkEldar : Program
    {
        [Homeworld(city = "Commorragh", rulebook_version = 5, name1 = "Accessor")]
        string nsm;
        public void Attr()
        {
            //[Homeworld(city = "Commorragh", rulebook_version = 5, name1 = "Accessor")]

            PrintAuthorInfo(typeof(DarkEldar));
            string nsm;
        }

        public static void PrintAuthorInfo(Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.
            //System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.
            //ProtertiesInfo[] MyMemberInfo = t.GetProperties();
            MemberInfo[] MyMemberInfo = t.GetMethods();
            Console.WriteLine(MyMemberInfo[0].ToString());
            FieldInfo[] my = t.GetFields();
            //PropertyInfo[] MyFieldInfo = t.GetProperties();
            Console.WriteLine(my[0].ToString());
            
            //Console.WriteLine("No attribute in member function {0}.\n" , MyMemberInfo[1].ToString());
            
            // Displaying output.
            /*foreach (System.Attribute attr in attrs)
            {
                if (attr is Homeworld)
                {
                    Homeworld h = (Homeworld)attr;
                    System.Console.WriteLine("   {0}, version {1}, {2}", h.city, h.rulebook_version);
                }
            }*/
        }
    }
}
