using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BranchRepository : BaseRepository<Branch>
    {
        //internal BranchRepository(LMSTSContext context) : base(context)
        //{
        //}
        public BranchRepository(LMSTSContext context) : base(context)
        {

        }
    }
}
