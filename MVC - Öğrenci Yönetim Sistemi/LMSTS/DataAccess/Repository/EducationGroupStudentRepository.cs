using _01_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EducationGroupStudentRepository : BaseRepository<Education_Group_Student>
    {
        internal EducationGroupStudentRepository(LMSTSContext context) : base(context)
        {
        }
    }
}
