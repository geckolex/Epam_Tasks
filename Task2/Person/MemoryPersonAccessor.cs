using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Person
{
    class MemoryPersonAccessor : IPersonAccessor
    {
        static ArrayList name = new ArrayList();
        static ArrayList value = new ArrayList();


        public void CreateList()
        {
            name.Add("Campbell");
            name.Add("Snake");
            name.Add("Otacon");
            name.Add("Revolver");
            value.Add("colonel");
            value.Add("special agent");
            value.Add("analyst");
            value.Add("bad guy");
        }
        
        public void GetAll()
        {
            Console.WriteLine("Ввывод всех имен и значений");
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine("{0} = {1}", name[i], value[i]);
            }
        }

        public void GetByName()
        {
            Console.WriteLine("Введите имя для поиска");
            string s = Console.ReadLine();
            for (int i = 0; i < name.Count; i++)
            {
                string n = name[i].ToString();
                if (s == n)
                {
                    Console.WriteLine("{0} = {1}", name[i], value[i]);
                }
            }
            if (!name.Contains(s))
            {
                Console.WriteLine("Имя не найдено");
            }
        }

        public void Update()
        {
            Console.WriteLine("Для изменения значения введите имя");
            string s = Console.ReadLine();
            for (int i = 0; i < name.Count; i++)
            {
                string n = name[i].ToString();
                if (s == n)
                {
                    Console.WriteLine("Введите новое значение");
                    string s1 = Console.ReadLine();
                    value[i] = s1;
                    Console.WriteLine("{0} = {1}", name[i], value[i]);
                }
            }
            if (!name.Contains(s))
            {
                Console.WriteLine("Имя не найдено");
            }

            GetAll();
        }

        public void Add()
        {
            Console.WriteLine("Для добавления нового элемента введите имя");
            string n = Console.ReadLine();
            name.Add(n);

            Console.WriteLine("Для добавления нового элемента введите значение");
            string v = Console.ReadLine();
            value.Add(v);

            GetAll();
        }

        public void Delete()
        {
            Console.WriteLine("Введите имя для удаления");
            string s = Console.ReadLine();
            if (!name.Contains(s))
            {
                Console.WriteLine("Имя не найдено");
            }
            for (int i = 0; i < name.Count; i++)
            {
                string n = name[i].ToString();
                if (s == n)
                {
                    name.RemoveAt(i);
                    value.RemoveAt(i);
                    
                    GetAll();
                }
            }
        }
    }
}
