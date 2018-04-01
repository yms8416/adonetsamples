using BilgeAdam.Northwind.Business.Enums;
using BilgeAdam.Northwind.Business.Helpers;
using BilgeAdam.Northwind.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgeAdam.Northwind.Business.Dtos;

namespace BilgeAdam.Northwind.Business.Repositories
{
    public class EmployeeRepository : RepositoryBase
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            var query = @"SELECT e.BusinessEntityId, e.BirthDate, e.MaritalStatus AS [Status], e.Gender, p.FirstName, p.LastName FROM HumanResources.Employee e
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
                    Id = Convert.ToInt32(reader["BusinessEntityId"]),
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

        public bool SaveEmployee(EmployeeDto employee)
        {
            var tran = Connection.BeginTransaction();
            try //exception handler ile de çözülebilir
            {
                #region Business Entity Kaydı
                //TODO: ortak methoda çek
                var beQuery = @"INSERT INTO Person.BusinessEntity(rowguid, ModifiedDate)
                            VALUES (@rq, @md) SELECT @@IDENTITY";
                var beCmd = new SqlCommand(beQuery, Connection);
                beCmd.Parameters.AddWithValue("@rq", Guid.NewGuid());
                beCmd.Parameters.AddWithValue("@md", DateTime.Now);
                var beReader = beCmd.ExecuteReader();
                var businessEntityId = 0;
                if (beReader.Read())
                {
                    businessEntityId = Convert.ToInt32(beReader[0]);
                }
                if (businessEntityId == 0)
                {
                    tran.Rollback();
                    throw new Exception("Kayıt yapılamadı");
                }
                beReader.Close();
                #endregion

                #region Employee Kaydı
                var empQuery = $@"INSERT INTO HumanResources.Employee
                             (BusinessEntityID, NationalIDNumber, LoginID, JobTitle, BirthDate, MaritalStatus, Gender, HireDate, SalariedFlag, VacationHours, SickLeaveHours, rowguid, ModifiedDate)
                             VALUES({businessEntityId}, @nnm, @login, @title, @bd, @ms, @gd, @hd, {1}, {employee.VacationHours}, {employee.SickLeaveHours}, NEWID(), GETDATE())";
                var empCmd = new SqlCommand(empQuery, Connection);
                empCmd.Parameters.AddWithValue("@nnm", employee.NationalNumber);
                empCmd.Parameters.AddWithValue("@login", employee.LoginName);
                empCmd.Parameters.AddWithValue("@title", employee.Title);
                empCmd.Parameters.AddWithValue("@bd", employee.BirthDate);
                empCmd.Parameters.AddWithValue("@ms", employee.MarrialStatus == MarrialStatus.Married ? "M" : "S");
                empCmd.Parameters.AddWithValue("@gd", employee.Gender == Gender.Female ? "F" : "M");
                empCmd.Parameters.AddWithValue("@hd", employee.HireDate);
                var eResult = empCmd.ExecuteNonQuery();
                #endregion

                #region Person Kaydı
                var perQuery = $@"INSERT INTO Person.Person 
                             (BusinessEntityID, PersonType, NameStyle, Title, FirstName, LastName, EmailPromotion, rowguid, ModifiedDate)
                             VALUES ({businessEntityId}, 'EM', 0, @title, @fn, @ln, 2, NEWID(), GETDATE())";
                var perCmd = new SqlCommand(perQuery, Connection);
                perCmd.Parameters.AddWithValue("@title", employee.Title);
                perCmd.Parameters.AddWithValue("@fn", employee.FirstName);
                perCmd.Parameters.AddWithValue("@ln", employee.LastName);
                var pResult = perCmd.ExecuteNonQuery();
                #endregion
                return eResult > 0 && pResult > 0;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            var query = @"DELETE FROM HumanResources.Employee WHERE BusinessEntityID = @id
                          DELETE FROM Person.Person WHERE BusinessEntityID = @id
                          DELETE FROM Person.BusinessEntity WHERE BusinessEntityID = @id";
            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@id", id);
            var result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public IEnumerable<Employee> GetAllEmployeesByFilter(EmployeeBasicFilter filter)
        {
            var list = new List<Employee>();
            var query = @"SELECT e.BusinessEntityId, e.BirthDate, e.MaritalStatus AS [Status], e.Gender, p.FirstName, p.LastName FROM HumanResources.Employee e
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
