using _01_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class Education_Group_StudentMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Education_Group_Student> egsConfig = modelBuilder.Entity<Education_Group_Student>();

            egsConfig.HasKey(x => new { x.StudentID, x.EducationGroupID });


        }
    }
}
