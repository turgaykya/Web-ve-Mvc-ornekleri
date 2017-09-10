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
    public class BranchMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Branch> branchConfig = modelBuilder.Entity<Branch>();

            branchConfig.HasKey(x => x.Id);
            branchConfig.Property(x => x.Name).IsRequired().HasColumnType("varchar");
        }
    }
}
