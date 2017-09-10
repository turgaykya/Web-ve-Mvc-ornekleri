using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OptionRepository : BaseRepository<Option>
    {
        internal OptionRepository(LMSTSContext context) : base(context)
        {
        }
    }
}
