using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Student
    {
        public Student()
        {
            HomeworkDeliverys =new HashSet<HomeworkDelivery>();
            EducationGroups = new HashSet<EducationGroup>();
            Answers = new HashSet<Answer>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EducationBranchID { get; set; }
        public int GenderID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsOnline { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool EducationGrouoStatus { get; set; }

        public virtual ICollection<HomeworkDelivery> HomeworkDeliverys { get; set; }
        public virtual ICollection<EducationGroup> EducationGroups { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual EducationBranch EducationBranch { get; set; }
        public virtual Login Login { get; set; }
    }
}
