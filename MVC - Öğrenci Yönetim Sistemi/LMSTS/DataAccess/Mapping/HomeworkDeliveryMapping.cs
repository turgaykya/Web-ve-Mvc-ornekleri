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
    public class HomeworkDeliveryMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<HomeworkDelivery> hWDeliveryConfig = modelBuilder.Entity<HomeworkDelivery>();
            hWDeliveryConfig.HasKey(hwd => hwd.Id);
            hWDeliveryConfig.Property(hwd => hwd.DateOfDelivery).IsRequired().HasColumnType("date");

            hWDeliveryConfig.HasRequired(hwd => hwd.Homework).WithMany(hwd => hwd.HomeworkDeliverys).HasForeignKey(hwd => hwd.HomeworkID).WillCascadeOnDelete(false);

            hWDeliveryConfig.HasRequired(hwd => hwd.Student).WithMany(hwd => hwd.HomeworkDeliverys).HasForeignKey(hwd => hwd.StudentID).WillCascadeOnDelete(false);
        }
    }
}
