using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMSTS.Models
{
    public class StudentListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public string EducationBranchName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool IsOnline { get; set; }
        public bool Status { get; set; }
        public string CitizenNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int GenderID { get; set; }
    }
}