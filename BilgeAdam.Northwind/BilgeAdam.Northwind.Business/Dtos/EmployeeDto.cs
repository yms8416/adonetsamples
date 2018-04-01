using BilgeAdam.Northwind.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Northwind.Business.Dtos
{
    public class EmployeeDto
    {
        public string NationalNumber { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public Gender Gender { get; set; }
        public MarrialStatus MarrialStatus { get; set; }
        public string LoginName { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public string Title { get; set; }
    }
}
