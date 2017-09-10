using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
   public class LogSystemLogin
    {
        public int UserID { get; set; }
        public DateTime DateOfSystemLogin { get; set; }
        public Nullable<DateTime> DateOfSystemLogout { get; set; }

        public virtual Login User { get; set; }
    }
}
