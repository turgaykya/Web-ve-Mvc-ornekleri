using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
    public class LogPage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfPageOpen { get; set; }
        public DateTime DateOfPageClose { get; set; }

        public virtual Login User { get; set; }

    }
}
