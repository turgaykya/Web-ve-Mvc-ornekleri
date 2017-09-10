using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class EducationGroup
    {
        public EducationGroup()
        {
            Subjects = new HashSet<Subject>();
            Homeworks = new HashSet<Homework>();
            Students = new HashSet<Student>();
            Topics = new HashSet<Topic>();
        }
        public int Id { get; set; }
        public int TrainerID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfEnd { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
