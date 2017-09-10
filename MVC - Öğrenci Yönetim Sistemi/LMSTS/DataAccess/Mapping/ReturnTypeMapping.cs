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
    public class ReturnTypeMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<ReturnType> rtConfig = modelBuilder.Entity<ReturnType>();

            rtConfig.HasKey(x => x.Id);
            rtConfig.Property(x => x.Name).IsRequired().HasColumnType("varchar");
        }
    }
}
