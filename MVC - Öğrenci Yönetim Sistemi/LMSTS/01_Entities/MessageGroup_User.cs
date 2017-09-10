using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
  public  class MessageGroup_User
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int MessageGroupID { get; set; }
        public virtual Login User { get; set; }
        public virtual MessageGroup MessageGroup { get; set; }
    }
}
