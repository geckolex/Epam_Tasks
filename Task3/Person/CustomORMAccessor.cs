using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Reflection;

namespace Task3
{
    class CustomORMAccessor : IPersonAccessorDB
    {
        SqlCeConnection connection = new SqlCeConnection(@"Data Source=D:\C#\HomeWork\Task3\Person\Database.sdf");

        public void GetAll(Type t)
        {
            connection.Open();
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

            foreach (System.Attribute attr in attrs)
            {
                if (attr is Attribut)
                {
                    Attribut att = (Attribut)attr;
                    string query = "SELECT * FROM " + att.TableName + "";
                    SqlCeCommand command = new SqlCeCommand(query, connection);
                    SqlCeDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        Console.WriteLine("{0}={1}",
                                            read[0].ToString(),
                                            read[1].ToString());
                    }
                }
            }
            connection.Close();
        }

        public void GetByName(FieldInfo fieldInfo, Type t)
        {
            Console.WriteLine("Введите Имя для поиска");
            System.Attribute[] attrtable = System.Attribute.GetCustomAttributes(t);
            connection.Open();
            foreach (System.Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    System.Attribute[] attrcolum1 = System.Attribute.GetCustomAttributes(fieldInfo);
                    foreach (System.Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            String nm = Console.ReadLine();
                            string query = @"SELECT * FROM " + attt.TableName + " WHERE " + attc1.Colum1 + "='" + nm + "'";

                            SqlCeCommand command = new SqlCeCommand(query, connection);
                            SqlCeDataReader read = command.ExecuteReader();

                            while (read.Read())
                            {
                                Console.WriteLine("{0}={1}",
                                                    read[0].ToString(),
                                                    read[1].ToString());
                            }
                        }
                    }

                }
            }
            connection.Close();
        }

        public void Update(FieldInfo fieldInfo, FieldInfo fieldInfo2, Type t)
        {
            Console.WriteLine("Для поиска введите имя");
            string n = Console.ReadLine();
            Console.WriteLine("Введите измененное значение");
            string v = Console.ReadLine();
            System.Attribute[] attrtable = System.Attribute.GetCustomAttributes(t);

            connection.Open();

            /*foreach (System.Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    System.Attribute[] attrcolum1 = System.Attribute.GetCustomAttributes(fieldInfo);
                    foreach (System.Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            //String nm = Console.ReadLine();
                            string query = @"UPDATE " + attt.TableName + " SET VALUE = '" + v + "' WHERE "+ attc1.Colum1 +" = '" + n + "'";
                            SqlCeCommand command = new SqlCeCommand(query, connection);
                            SqlCeDataReader read = command.ExecuteReader();
                            while (read.Read())
                            {
                                Console.WriteLine("{0}={1}",
                                                    read[0].ToString(),
                                                    read[1].ToString());
                            }
                        }
                    }
                }
            }*/

            foreach (System.Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    System.Attribute[] attrcolum1 = System.Attribute.GetCustomAttributes(fieldInfo);
                    foreach (System.Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            System.Attribute[] attrcolum2 = System.Attribute.GetCustomAttributes(fieldInfo2);

                            foreach (System.Attribute attrcol2 in attrcolum2)
                            {
                                if (attrcol2 is Attribut)
                                {
                                    Attribut attc2 = (Attribut)attrcol2;
                                    string query = @"UPDATE " + attt.TableName + " SET " + attc2.Colum2 + " = '" + v + "' WHERE " + attc1.Colum1 + " = '" + n + "'";
                                    SqlCeCommand command = new SqlCeCommand(query, connection);
                                    command.ExecuteNonQuery();
                                }
                            }

                        }
                    }
                }
            }
            connection.Close();
        }

        public void Add(FieldInfo fieldInfo, FieldInfo fieldInfo2, Type t)
        {
            Console.WriteLine("Для добавления введите имя");
            string n = Console.ReadLine();
            Console.WriteLine("Для добавления введите значение");
            string v = Console.ReadLine();
            System.Attribute[] attrtable = System.Attribute.GetCustomAttributes(t);

            connection.Open();

            foreach (System.Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    System.Attribute[] attrcolum1 = System.Attribute.GetCustomAttributes(fieldInfo);
                    foreach (System.Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            System.Attribute[] attrcolum2 = System.Attribute.GetCustomAttributes(fieldInfo2);

                            foreach (System.Attribute attrcol2 in attrcolum2)
                            {
                                if (attrcol2 is Attribut)
                                {
                                    Attribut attc2 = (Attribut)attrcol2;
                                    string query = @"INSERT INTO " + attt.TableName + " (" + attc1.Colum1 + ", " + attc2.Colum2 + ") VALUES ('" + n + "', '" + v + "')";
                                    SqlCeCommand command = new SqlCeCommand(query, connection);
                                    command.ExecuteNonQuery();
                                }
                            }
                            
                        }
                    }
                }
            }
            connection.Close();
        }

        public void Delete(FieldInfo fieldInfo, Type t)
        {
            Console.WriteLine("Для удаления введите имя");
            string n = Console.ReadLine();
            connection.Open();
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

            foreach (System.Attribute attr in attrs)
            {
                if (attr is Attribut)
                {
                    Attribut att = (Attribut)attr;
                    Attribute[] attrcolum1 = Attribute.GetCustomAttributes(fieldInfo);
                    foreach (Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            Console.WriteLine("Введите Имя");
                            String nm = Console.ReadLine();
                            string query = @"DELETE FROM " + att.TableName + " WHERE " + attc1.Colum1 + "='" + n + "'";
                            SqlCeCommand command = new SqlCeCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            connection.Close();
        }
    }
}
