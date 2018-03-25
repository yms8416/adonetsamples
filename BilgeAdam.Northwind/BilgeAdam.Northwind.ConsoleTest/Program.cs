using System;
using System.Data;
using System.Data.SqlClient;

namespace BilgeAdam.Northwind.ConsoleTest
{
    class Program
    {
        //static memberlar içerisinden sadece static olanlara erişilebilir
        static void Main(string[] args)
        {
            var connection = Connect();
            GetProducts(connection);

            Console.ReadKey();
        }

        static SqlConnection Connect()
        {
            var connectionstring = "Server=10.11.33.118;Database=AdventureWorks2014;User Id=yms8416;Password=sifre";
            var connection = new SqlConnection(connectionstring);
            if (connection.State != ConnectionState.Open)//Bağlantı açık değilse bağlan
            {
                connection.Open();
            }
            if (connection.State == ConnectionState.Open)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bağlandı....");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bağlantı Sağlanamadı!");
            }

            return connection;
        }

        static void GetProducts(SqlConnection connection)
        {
            //ADO.NET ---> ActiveX Data Objects
            Console.ForegroundColor = ConsoleColor.Black;
            var query = "SELECT Name, ProductNumber, StandardCost, ListPrice FROM Production.Product WHERE ListPrice > 0";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,8} {1,40} {2,15} {3,15}", reader["ProductNumber"], reader["Name"], reader["StandardCost"], reader["ListPrice"]);
            }
        }
    }
}
