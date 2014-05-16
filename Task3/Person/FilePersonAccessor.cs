using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Task3
{
    class FilePersonAccessor : IPersonAccessor
    {
        ArrayList fname = new ArrayList();
        ArrayList fvalue = new ArrayList();

        string filename = "DataFile.txt";
        
        public void Parser()
        {
            try
            {
                String line;
                using (StreamReader sr = new StreamReader(filename))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] ss = line.Split('=');
                        fname.Add(ss[0]);
                        fvalue.Add(ss[1]);
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void Rewriter()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    for (int i = 0; i < fname.Count; i++)
                    {
                        if (i != fname.Count - 1)
                        {
                            sw.Write("{0}={1}\n", fname[i], fvalue[i]);
                        }
                        else
                        {
                            sw.Write("{0}={1}", fname[i], fvalue[i]);
                        }
                    }
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public void GetAll()
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void GetByName()
        {
            Console.WriteLine("Введите имя для поиска");
            string s = Console.ReadLine();
            for (int i = 0; i < fname.Count; i++)
            {
                string n = fname[i].ToString();
                if (s == n)
                {
                    Console.WriteLine("{0} = {1}", fname[i], fvalue[i]);
                }
            }
            if (!fname.Contains(s))
            {
                Console.WriteLine("Имя не найдено");
            }
        }

        public void Update()
        {
            Console.WriteLine("Для изменения значения введите имя");
            string s = Console.ReadLine();
            for (int i = 0; i < fname.Count; i++)
            {
                string n = fname[i].ToString();
                if (s == n)
                {
                    Console.WriteLine("Введите новое значение");
                    string s1 = Console.ReadLine();
                    fvalue[i] = s1;                    
                }
            }
            if (!fname.Contains(s))
            {
                Console.WriteLine("Имя не найдено");
            }
            Rewriter();
            GetAll();
        }

        public void Add()
        {
            Console.WriteLine("Для добавления нового элемента введите имя");
            string n = Console.ReadLine();
            fname.Add(n);

            Console.WriteLine("Для добавления нового элемента введите значение");
            string v = Console.ReadLine();
            fvalue.Add(v);

            Rewriter();
            GetAll();
        }

        public void Delete()
        {
            Console.WriteLine("Введите имя для удаления");
            string s = Console.ReadLine();
            if (!fname.Contains(s))
            {
                Console.WriteLine("Имя не найдено");
            }
            for (int i = 0; i < fname.Count; i++)
            {
                string n = fname[i].ToString();
                if (s == n)
                {
                    fname.RemoveAt(i);
                    fvalue.RemoveAt(i);

                    Rewriter();
                    GetAll();
                }
            }
        }
    }
}
