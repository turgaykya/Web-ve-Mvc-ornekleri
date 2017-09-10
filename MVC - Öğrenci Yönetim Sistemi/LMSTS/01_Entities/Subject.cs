using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
    public class Subject
    {
        public Subject()
        {
            Contents = new HashSet<Content>();
            Questions = new HashSet<Question>();
            Homeworks = new HashSet<Homework>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int EducationGroupID { get; set; }
        public DateTime DateOfCreation { get; set; }

        public virtual EducationGroup EducationGroup { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
