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
    public class EducationGroupMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<EducationGroup> egmConfig = modelBuilder.Entity<EducationGroup>();

            egmConfig.HasKey(x=>x.Id);
            egmConfig.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            egmConfig.Property(x => x.DateOfCreation).IsRequired().HasColumnType("date");
            egmConfig.Property(x => x.DateOfEnd).IsRequired().HasColumnType("date");

            egmConfig.HasRequired(x => x.Trainer).WithMany(x => x.EducationGroups)
                .HasForeignKey(x => x.TrainerID)
                .WillCascadeOnDelete(false);

                
        }
    }
}
