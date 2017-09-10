using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int TopicID { get; set; }

        public int UserID { get; set; }

        public DateTime DateOfComment { get; set; }

        public string Description { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual Login Login { get; set; }


    }
}
