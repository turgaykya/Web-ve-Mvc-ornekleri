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
    public class LogPageMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<LogPage> logePage = modelBuilder.Entity<LogPage>();

            logePage.HasKey(lp => lp.Id);
            logePage.Property(lp => lp.Url).IsRequired().HasColumnType("nvarchar").HasMaxLength(2000);
            logePage.Property(lp => lp.Title).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            logePage.Property(lp => lp.DateOfPageOpen).IsRequired().HasColumnType("date");
            logePage.Property(lp => lp.DateOfPageClose).IsRequired().HasColumnType("date");

            logePage.HasRequired(lp => lp.User).WithMany(lp => lp.LogePages).HasForeignKey(lp => lp.UserID).WillCascadeOnDelete(false);

        }
    }
}
