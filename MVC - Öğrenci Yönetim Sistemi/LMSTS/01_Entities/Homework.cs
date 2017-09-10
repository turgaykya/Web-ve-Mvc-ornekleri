using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
  public  class Homework
    {
        public Homework()
        {
            HomeworkDeliverys = new HashSet<HomeworkDelivery>();
        }
        public int Id { get; set; }
        public int SubjectID { get; set; }
        public int TrainerID { get; set; }
        public int EducationGroupID { get; set; }
        public string Document { get; set; }
        public DateTime DateOfAssingment { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public virtual Subject Subjects { get; set; }
        public virtual Trainer Trainers { get; set; }
        public virtual EducationGroup EducationGroup { get; set; }
        public virtual ICollection<HomeworkDelivery> HomeworkDeliverys { get; set; }

    }
}
