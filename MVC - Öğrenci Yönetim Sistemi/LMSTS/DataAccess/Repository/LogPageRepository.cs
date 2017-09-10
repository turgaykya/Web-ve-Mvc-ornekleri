using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class LogPageRepository : BaseRepository<LogPage>
    {
        internal LogPageRepository(LMSTSContext context) : base(context)
        {
        }
    }
}
