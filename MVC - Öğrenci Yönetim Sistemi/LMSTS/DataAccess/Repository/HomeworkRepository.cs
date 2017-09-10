using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class HomeworkRepository : BaseRepository<Homework>
    {
        internal HomeworkRepository(LMSTSContext context) : base(context)
        {
        }
    }
}
