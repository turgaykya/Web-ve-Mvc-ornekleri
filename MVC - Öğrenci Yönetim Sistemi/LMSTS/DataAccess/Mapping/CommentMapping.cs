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
    public class CommentMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Comment> commentConfig = modelBuilder.Entity<Comment>();

            commentConfig.HasKey(x => x.Id);

            commentConfig.Property(x => x.DateOfComment).IsRequired().HasColumnType("datetime");
            commentConfig.Property(x => x.Description).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);

            commentConfig.HasRequired(x => x.Topic).WithMany(x => x.Comments).HasForeignKey(x => x.TopicID);
            commentConfig.HasRequired(x => x.Login).WithMany(x => x.Comments).HasForeignKey(x => x.UserID);

        }
    }
}
