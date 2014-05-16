using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlServerCe;

namespace Task3
{
    class AdoNetAccessor : IPersonAccessor
    {
        SqlCeConnection connection = new SqlCeConnection(@"Data Source=D:\C#\HomeWork\Task3\Person\Database.sdf");

        public void GetAll()
        {
            connection.Open();

            string query = "SELECT * FROM Accessor";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            SqlCeDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                Console.WriteLine("{0}={1}",
                                    read["NAME"].ToString(),
                                    read["VALUE"].ToString());
            }
            connection.Close();
        }

        public void GetByName()
        {
            Console.WriteLine("Для поиска введите имя");
            string n = Console.ReadLine();
            
            connection.Open();

            string query = @"SELECT * FROM Accessor WHERE NAME = '" + n + "'";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            SqlCeDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                Console.WriteLine("{0}={1}",
                                    read["NAME"].ToString(),
                                    read["VALUE"].ToString());
            }

            connection.Close();
        }

        public void Update()
        {
            Console.WriteLine("Для поиска введите имя");
            string n = Console.ReadLine();
            Console.WriteLine("Введите измененное значение");
            string v = Console.ReadLine();

            connection.Open();

            string query = @"UPDATE Accessor SET VALUE = '" + v + "' WHERE NAME = '" + n + "'";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();

            GetAll();
        }

        public void Add()
        {
            Console.WriteLine("Для добавления введите имя");
            string n = Console.ReadLine();
            Console.WriteLine("Для добавления введите значение");
            string v = Console.ReadLine();
            
            connection.Open();

            string query = @"INSERT INTO Accessor (NAME, VALUE) VALUES ('" + n + "', '" + v + "')";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();

            GetAll();
        }

        public void Delete()
        {
            Console.WriteLine("Для для удаления введите имя");
            string n = Console.ReadLine();
            

            connection.Open();

            string query = @"DELETE FROM Accessor WHERE NAME = '" + n + "'";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();

            GetAll();
        }


        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
    }
}
