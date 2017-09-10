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
    public class GenderMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Gender> genderConfig = modelBuilder.Entity<Gender>();

            genderConfig.HasKey(x => x.Id);
            genderConfig.Property(x => x.Name).IsRequired().HasMaxLength(5);

        }
    }
}
