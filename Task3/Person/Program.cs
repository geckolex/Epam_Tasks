using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*MenuOption mo = new MenuOption();
            mo.MainMenu();
            */
            //AdoNetAccessor ana = new AdoNetAccessor();
            //ana.GetAll();
            //ana.Add();
            //ana.GetByName();
            //ana.Update();
            //ana.Delete();

            CustomORMAccessor coa = new CustomORMAccessor();
            coa.GetAll(typeof(Person));
            //coa.GetByName(typeof(Person).GetField("name"), typeof(Person));
            //coa.Update(typeof(Person).GetField("name"), typeof(Person));
            //coa.Add(typeof(Person).GetField("name"), typeof(Person).GetField("value"), typeof(Person));
            coa.Delete(typeof(Person));


            Console.ReadKey();
        }
    }
}
