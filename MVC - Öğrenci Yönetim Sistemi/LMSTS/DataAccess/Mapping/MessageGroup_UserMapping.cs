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
    public class MessageGroup_UserMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<MessageGroup_User> messageGroupUserConfig = modelBuilder.Entity<MessageGroup_User>();
            messageGroupUserConfig.HasKey(mgu => mgu.Id);
            messageGroupUserConfig.HasRequired(mgu => mgu.User).WithMany(mgu => mgu.MessageGroupUsers).HasForeignKey(mgu => mgu.UserID).WillCascadeOnDelete(false);

            messageGroupUserConfig.HasRequired(mgu => mgu.MessageGroup).WithMany(mgu => mgu.MessageGroupUsers).HasForeignKey(mgu => mgu.MessageGroupID).WillCascadeOnDelete(false);


        }
    }
}
