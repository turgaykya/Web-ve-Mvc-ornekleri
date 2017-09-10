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
    public class TitleMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Title> titleConfig = modelBuilder.Entity<Title>();

            titleConfig.HasKey(x => x.Id);
            titleConfig.Property(x => x.Name).IsRequired();

        }
    }
}
