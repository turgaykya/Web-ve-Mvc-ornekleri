using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class ReturnType
    {
        public ReturnType()
        {
            HomeworkReturns = new HashSet<HomeworkReturn>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HomeworkReturn> HomeworkReturns { get; set; }

    }
}
