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
    public class HomeworkMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Homework> hwConfig = modelBuilder.Entity<Homework>();

            hwConfig.HasKey(x => x.Id);
            hwConfig.Property(x => x.Document).IsOptional().HasColumnType("nvarchar").HasMaxLength(300);
            hwConfig.Property(x => x.DateOfAssingment).IsRequired().HasColumnType("date");
            hwConfig.Property(x => x.Deadline).IsRequired().HasColumnType("date");
            hwConfig.Property(x => x.Description).IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);

            hwConfig.HasRequired(x => x.Subjects).WithMany(x => x.Homeworks)
                .HasForeignKey(x => x.SubjectID)
                .WillCascadeOnDelete(false);

            hwConfig.HasRequired(x => x.Trainers).WithMany(x => x.Homeworks)
                .HasForeignKey(x => x.TrainerID)
                .WillCascadeOnDelete(false);

            hwConfig.HasRequired(x => x.EducationGroup).WithMany(x => x.Homeworks)
                .HasForeignKey(x => x.EducationGroupID)
                .WillCascadeOnDelete(false);



        }
    }
}
