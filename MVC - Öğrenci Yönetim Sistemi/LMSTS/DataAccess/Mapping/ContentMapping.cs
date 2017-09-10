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
    public class ContentMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Content> contentConfig = modelBuilder.Entity<Content>();

            contentConfig.HasKey(x => x.Id);
            contentConfig.Property(x => x.Document).IsRequired().HasColumnType("nvarchar");
            contentConfig.Property(x => x.DateOfCreation).IsRequired().HasColumnType("date");

            contentConfig.HasRequired(x => x.Subject).WithMany(x => x.Contents).HasForeignKey(x => x.SubjectID);
        }
    }
}
