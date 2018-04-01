using BilgeAdam.Northwind.Business.Enums;
using System;
using System.ComponentModel;

namespace BilgeAdam.Northwind.Business.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Adı")]
        public string FirstName { get; set; }
        [DisplayName("Soyadı")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public MarrialStatus Status { get; set; }
        public Gender Gender { get; set; }
    }
}
