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
    public class MessageMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Message> messageConfig = modelBuilder.Entity<Message>();

            messageConfig.HasKey(m => m.Id);
            messageConfig.Property(m => m.Content).IsRequired().HasColumnType("varchar").HasMaxLength(2000);
            messageConfig.Property(m => m.DateOfSend).IsRequired().HasColumnType("date");

            messageConfig.HasRequired(m => m.User).WithMany(m => m.Messages).HasForeignKey(m => m.UserID).WillCascadeOnDelete(false);
            messageConfig.HasRequired(m => m.MessageGroup).WithMany(m => m.Messages).HasForeignKey(m => m.MessageGroupID).WillCascadeOnDelete(false);


        }
    }
}
