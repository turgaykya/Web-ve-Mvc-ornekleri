using _01_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Mapping
{
    public class LoginMapping
    {

        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Login> loginConfig = modelBuilder.Entity<Login>();

            loginConfig.HasKey(x => x.Id);
            loginConfig.Property(x=>x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            loginConfig.Property(x => x.UserName).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            loginConfig.Property(x => x.Mail).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            loginConfig.Property(x => x.Password).IsRequired().HasColumnType("nvarchar").HasMaxLength(36);
            loginConfig.Property(x => x.CitizenNumber).IsRequired().HasColumnType("char").HasMaxLength(11);
            loginConfig.HasRequired(x => x.Student).WithRequiredPrincipal(x => x.Login);
            loginConfig.HasRequired(x => x.Trainer).WithRequiredPrincipal(x => x.Login);
        }
    }
}
