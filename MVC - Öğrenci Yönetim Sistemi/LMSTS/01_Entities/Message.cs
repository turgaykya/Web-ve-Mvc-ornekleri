using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
  public  class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public int MessageGroupID { get; set; }
        public DateTime DateOfSend { get; set; }


        public virtual Login User { get; set; }
        public virtual MessageGroup MessageGroup { get; set; }

    }
}
