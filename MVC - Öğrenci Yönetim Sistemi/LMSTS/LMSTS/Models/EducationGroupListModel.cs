using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMSTS.Models
{
    public class EducationGroupListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }
        public DateTime DateOfCrecation { get; set; }
        public DateTime DateOfEnd { get; set; }
        
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public string EducationBranchName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool IsOnline { get; set; }
        public bool Status { get; set; }
        public List<StudentListModel> StudentList { get; set; }
    }
}