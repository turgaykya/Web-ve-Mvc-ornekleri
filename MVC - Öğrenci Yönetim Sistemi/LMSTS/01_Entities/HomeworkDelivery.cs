using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class HomeworkDelivery
    {
        public HomeworkDelivery()
        {
            HomeworkReturns = new HashSet<HomeworkReturn>();
        }
        public int Id { get; set; }
        public int HomeworkID { get; set; }
        public int StudentID { get; set; }
        public DateTime DateOfDelivery { get; set; }

        public virtual Homework Homework { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<HomeworkReturn> HomeworkReturns { get; set; }

    }
}
