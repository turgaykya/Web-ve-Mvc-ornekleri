using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Education_Group_Student
    {
        public int StudentID { get; set; }
        public int EducationGroupID { get; set; }
        public DateTime DateOfJoin { get; set; }

        public virtual Student Student { get; set; }
        public virtual EducationGroup EducationGroup { get; set; }
    }
}
