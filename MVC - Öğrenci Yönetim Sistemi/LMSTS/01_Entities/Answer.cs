using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class Answer
    {
        public int QuestionID { get; set; }
        public int StudentID { get; set; }
        public int OptionID { get; set; }

        public virtual Question Question { get; set; }
        public virtual Student Student { get; set; }
        public virtual Option Option { get; set; }
    }
}
