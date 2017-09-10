using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EducationGroupRepository : BaseRepository<EducationGroup>
    {
        internal EducationGroupRepository(LMSTSContext context) : base(context)
        {
        }
    }
}
