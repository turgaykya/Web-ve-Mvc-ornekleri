using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.EF.Entities
{
    public class Employee
    {
        public Employee()
        {

        }
        // Scalar Property
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Nullable<DateTime> HireDate { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }


        //navigetion property
        public virtual Department Department { get; set; }
    }
}
