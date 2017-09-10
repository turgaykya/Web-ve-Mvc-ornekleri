using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ContentRepository : BaseRepository<Content>
    {
        internal ContentRepository(LMSTSContext context) : base(context)
        {
        }
    }
}
