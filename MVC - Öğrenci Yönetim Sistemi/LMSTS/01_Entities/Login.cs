using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
  public  class Login
    {
        public Login()
        {
            Comments = new HashSet<Comment>();
            LogePages = new HashSet<LogPage>();
            LogSystemLogins = new HashSet<LogSystemLogin>();
            MessageGroupUsers = new HashSet<MessageGroup_User>();
            Messages = new HashSet<Message>();
            Topics = new HashSet<Topic>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string CitizenNumber { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<LogPage> LogePages { get; set; }
        public virtual ICollection<LogSystemLogin> LogSystemLogins { get; set; }
        public virtual ICollection<MessageGroup_User> MessageGroupUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
