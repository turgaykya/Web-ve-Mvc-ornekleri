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
    public class MessageGroupMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<MessageGroup> messageGroupConfig = modelBuilder.Entity<MessageGroup>();

            messageGroupConfig.HasKey(mg => mg.Id);
            messageGroupConfig.Property(mg => mg.Name).IsRequired().HasColumnType("varchar").HasMaxLength(100);

            messageGroupConfig.Property(mg => mg.DateOfCreation).IsRequired().HasColumnType("date");
            messageGroupConfig.Property(mg => mg.IsActive).IsRequired().HasColumnType("bit");

        }
    }
}
