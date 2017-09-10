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
    public class LogSystemLoginMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {

            EntityTypeConfiguration<LogSystemLogin> loginSystemConfig = modelBuilder.Entity<LogSystemLogin>();

            loginSystemConfig.HasKey(x => new { x.UserID, x.DateOfSystemLogin });

            loginSystemConfig.Property(x => x.DateOfSystemLogin).IsRequired().HasColumnType("date");
            loginSystemConfig.Property(x => x.DateOfSystemLogout).IsOptional().HasColumnType("date");


            loginSystemConfig.HasRequired(h => h.User).WithMany(h => h.LogSystemLogins)
         .HasForeignKey(h => h.UserID)
         .WillCascadeOnDelete(false);
        }
    }
}
