using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuOption mo = new MenuOption();
            mo.MainMenu();
            

            Console.ReadKey();
        }
    }
}
