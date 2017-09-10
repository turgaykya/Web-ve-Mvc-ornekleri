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
    public class EducationBranchMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<EducationBranch> ebConfig = modelBuilder.Entity<EducationBranch>();

            ebConfig.HasKey(x => x.Id);
            ebConfig.Property(x => x.Name).IsRequired().HasColumnType("varchar");
        }
    }
}
