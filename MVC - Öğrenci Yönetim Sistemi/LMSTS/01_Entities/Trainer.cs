using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Trainer
    {
        public Trainer()
        {
            EducationGroups = new HashSet<EducationGroup>();
            Homeworks = new HashSet<Homework>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BranchID { get; set; }
        public int TitleID { get; set; }
        public int GenderID { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }

        public bool IsOnline { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfRegistration { get; set; }

        public virtual Login Login { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Title Title { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<EducationGroup> EducationGroups { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }

    }
}