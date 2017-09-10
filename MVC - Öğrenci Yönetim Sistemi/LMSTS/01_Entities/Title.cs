using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Title
    {
        public Title()
        {
            Trainers = new HashSet<Trainer>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
