using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Content
    {
        public int Id { get; set; }

        public int SubjectID { get; set; }

        public string Document { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
