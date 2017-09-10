using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Option
    {
        public Option()
        {
            Answers = new HashSet<Answer>();
        }
        public int Id { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public bool TrueAnswer { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
