using BilgeAdam.Northwind.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return list;
        }
    }
}
