using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Topic
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public int EducationGroupID { get; set; }
        public int UserID { get; set; }
        public string Head { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Nullable<DateTime> DateOfLock { get; set; }
        public Nullable<short> Hit { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual EducationGroup EducationGroup { get; set; }
        public virtual Login Login { get; set; }
    }
}
