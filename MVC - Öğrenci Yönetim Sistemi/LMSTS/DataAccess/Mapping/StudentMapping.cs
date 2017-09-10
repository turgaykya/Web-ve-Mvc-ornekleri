using _01_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Mapping
{
    public class StudentMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {

            EntityTypeConfiguration<Student> studentConfig = modelBuilder.Entity<Student>();

            studentConfig.HasKey(x => x.Id);
            studentConfig.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            studentConfig.Property(x => x.FirstName).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            studentConfig.Property(x => x.LastName).IsRequired().HasMaxLength(50).HasColumnType("varchar");

            studentConfig.Property(x => x.IsOnline).IsRequired().HasColumnType("bit");
            studentConfig.Property(x => x.Status).IsRequired().HasColumnType("bit");

            studentConfig.Property(x => x.DateOfBirth).IsOptional().HasColumnType("date");
            studentConfig.Property(x => x.DateOfRegistration).IsRequired().HasColumnType("date");

            studentConfig.Property(x => x.EducationGrouoStatus).IsRequired().HasColumnType("bit");

            studentConfig.HasRequired(s => s.Gender).WithMany(s => s.Students)
            .HasForeignKey(s => s.GenderID)
            .WillCascadeOnDelete(false);

            studentConfig.HasRequired(s => s.EducationBranch).WithMany(s => s.Students)
            .HasForeignKey(s => s.EducationBranchID)
            .WillCascadeOnDelete(false);


            //Login deki userId burdaki Id olacak
          
        }
    }
}
