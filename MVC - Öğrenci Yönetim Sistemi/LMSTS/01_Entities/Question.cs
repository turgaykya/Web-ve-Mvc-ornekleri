using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            Options = new HashSet<Option>();
        }
        public int Id { get; set; }
        public int SubjectID { get; set; }
        public short Point { get; set; }
        public string Text { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
