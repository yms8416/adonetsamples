using BilgeAdam.Northwind.Business.Enums;
using BilgeAdam.Northwind.Business.Helpers;
using BilgeAdam.Northwind.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Northwind.Business.Repositories
{
    public class EmployeeRepository : RepositoryBase
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            var query = @"SELECT e.BirthDate, e.MaritalStatus AS [Status], e.Gender, p.FirstName, p.LastName FROM HumanResources.Employee e
                         INNER JOIN Person.Person p ON e.BusinessEntityID = p.BusinessEntityID
                         WHERE p.PersonType = 'EM'";
            var cmd = new SqlCommand(query, Connection);
            var reader = cmd.ExecuteReader();
            return MapEmployee(list, reader);
        }

        private static IEnumerable<Employee> MapEmployee(List<Employee> list, SqlDataReader reader)
        {
            while (reader.Read())
            {
                var emp = new Employee
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                    Gender = reader["Gender"].ToString() == "M" ? Gender.Male : Gender.Female,
                    Status = reader["Status"].ToString() == "M" ? MarrialStatus.Married : MarrialStatus.Single,
                };
                list.Add(emp);
                
                /*
                 * Ternery if
                    var gender ;
                    if(reader["Gender"].ToString() == "M")
                    {
                        gender = Gender.Male;
                    }
                    else
                    {
                        gender = Gender.Female;
                    }
                */
            }
            reader.Close();
            return list;
        }

        public IEnumerable<Employee> GetAllEmployeesByFilter(EmployeeBasicFilter filter)
        {
            var list = new List<Employee>();
            var query = @"SELECT e.BirthDate, e.MaritalStatus AS [Status], e.Gender, p.FirstName, p.LastName FROM HumanResources.Employee e
                         INNER JOIN Person.Person p ON e.BusinessEntityID = p.BusinessEntityID
                         WHERE p.PersonType = 'EM' AND e.MaritalStatus = @ms AND e.Gender = @gn";
            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@ms", filter.MarrialStatusText);
            cmd.Parameters.AddWithValue("@gn", filter.GenderText);
            var reader = cmd.ExecuteReader();
            MapEmployee(list, reader);
            return list;
        }
    }
}
