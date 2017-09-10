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
    public class TopicMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Topic> topicConfig = modelBuilder.Entity<Topic>();

            topicConfig.HasKey(x => x.Id);

            topicConfig.Property(x => x.Head).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            topicConfig.Property(x => x.Description).IsRequired().HasMaxLength(2000).HasColumnType("nvarchar");

            topicConfig.Property(x => x.IsActive).IsRequired().HasColumnType("bit");
            topicConfig.Property(x => x.Hit).IsOptional().HasColumnType("smallint");

            topicConfig.Property(x => x.DateOfCreation).IsRequired().HasColumnType("date");
            topicConfig.Property(x => x.DateOfLock).IsOptional().HasColumnType("date");

            topicConfig.HasRequired(t => t.Login).WithMany(t => t.Topics)
            .HasForeignKey(t => t.UserID)
            .WillCascadeOnDelete(false);

            topicConfig.HasRequired(t => t.EducationGroup).WithMany(t => t.Topics)
         .HasForeignKey(t => t.EducationGroupID)
         .WillCascadeOnDelete(false);


        }
    }
}
