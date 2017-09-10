using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class MessageGroup
    {
        public MessageGroup()
        {
            Messages = new HashSet<Message>();
            MessageGroupUsers = new HashSet<MessageGroup_User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<MessageGroup_User> MessageGroupUsers { get; set; }


    }
}
