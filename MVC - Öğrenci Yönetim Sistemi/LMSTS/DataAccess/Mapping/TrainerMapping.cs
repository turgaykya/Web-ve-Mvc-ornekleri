using _01_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class TrainerMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Trainer> trainerConfig = modelBuilder.Entity<Trainer>();

            trainerConfig.HasKey(x => x.Id);
            trainerConfig.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            trainerConfig.Property(x => x.FirstName).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            trainerConfig.Property(x => x.LastName).IsRequired().HasMaxLength(50).HasColumnType("varchar");

            trainerConfig.Property(x => x.IsOnline).IsRequired().HasColumnType("bit");
            trainerConfig.Property(x => x.Status).IsRequired().HasColumnType("bit");

            trainerConfig.Property(x => x.DateOfBirth).IsOptional().HasColumnType("date");
            trainerConfig.Property(x => x.DateOfRegistration).IsRequired().HasColumnType("date");

            trainerConfig.HasRequired(t => t.Branch).WithMany(t => t.Trainers)
            .HasForeignKey(t => t.BranchID)
            .WillCascadeOnDelete(false);


            trainerConfig.HasRequired(t => t.Gender).WithMany(t => t.Trainers)
            .HasForeignKey(t => t.GenderID)
            .WillCascadeOnDelete(false);

            trainerConfig.HasRequired(t => t.Title).WithMany(t => t.Trainers)
           .HasForeignKey(t => t.TitleID)
           .WillCascadeOnDelete(false);

            //Login deki userId burdaki Id olacak

        }
    }
}
