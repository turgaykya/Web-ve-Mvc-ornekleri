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
    public class HomeworkReturnMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {

            EntityTypeConfiguration<HomeworkReturn> homeworkReturnConfig = modelBuilder.Entity<HomeworkReturn>();

            homeworkReturnConfig.HasKey(x => x.Id);

            homeworkReturnConfig.Property(x => x.Description).IsRequired().HasMaxLength(2000).HasColumnType("varchar");

            homeworkReturnConfig.Property(x => x.EvaluationPoint).IsOptional().HasColumnType("smallint");


            homeworkReturnConfig.HasRequired(h => h.ReturnType).WithMany(h => h.HomeworkReturns)
     .HasForeignKey(h => h.ReturnTypeID)
     .WillCascadeOnDelete(false);

            homeworkReturnConfig.HasRequired(h => h.HomeworkDelivery).WithMany(h => h.HomeworkReturns)
         .HasForeignKey(h => h.HomeworkDeliveryID)
         .WillCascadeOnDelete(false);

            //Hata ama neden
        }
    }
}
