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
    public class SubjectMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {

            EntityTypeConfiguration<Subject> subjectConfig = modelBuilder.Entity<Subject>();

            subjectConfig.HasKey(x => x.Id);

            subjectConfig.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar");

            subjectConfig.Property(x => x.DateOfCreation).IsOptional().HasColumnType("date");
 

            subjectConfig.HasRequired(t => t.EducationGroup).WithMany(t => t.Subjects)
         .HasForeignKey(t => t.EducationGroupID)
         .WillCascadeOnDelete(false);
        }
    }
}
