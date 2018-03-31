using BilgeAdam.Northwind.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BilgeAdam.Northwind.Business.Repositories
{
    public class ProductRepository : RepositoryBase
    {
        public IEnumerable<Product> GetProducts()
        {
            var query = "SELECT Name, ProductNumber, StandardCost, ListPrice FROM Production.Product WHERE ListPrice > 0";
            var command = new SqlCommand(query, Connection);
            var reader = command.ExecuteReader();
            var list = new List<Product>();
            MapProducts(list, reader);
            return list;
        }

        public IEnumerable<Product> GetProductsByName(string filter)
        {
            var list = new List<Product>();
            var query = "SELECT Name, ProductNumber, StandardCost, ListPrice FROM Production.Product WHERE ListPrice > @listPrice AND Name LIKE @name";
            var cmd = new SqlCommand(query, Connection);

            cmd.Parameters.AddWithValue("@listPrice", 0);
            cmd.Parameters.Add(new SqlParameter("@name", filter + "%"));

            var reader = cmd.ExecuteReader();
            MapProducts(list, reader);
            return list;
        }

        private static void MapProducts(List<Product> list, SqlDataReader reader)
        {
            while (reader.Read())
            {
                var product = new Product
                {
                    Name = reader["Name"].ToString(),
                    ProductNumber = reader["ProductNumber"].ToString(),
                    ListPrice = Convert.ToDouble(reader["ListPrice"]),
                    StandardCost = Convert.ToDouble(reader["StandardCost"])
                };
                list.Add(product);
            }
            reader.Close();
        }
    }
}
