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
    public class OptionMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Option> optionConfig = modelBuilder.Entity<Option>();

            optionConfig.HasKey(o => o.Id);
            optionConfig.Property(o => o.Text).IsRequired().HasColumnType("varchar").HasMaxLength(2000);
            optionConfig.Property(o => o.TrueAnswer).IsRequired().HasColumnType("bit");

            optionConfig.HasRequired(o => o.Question).WithMany(o => o.Options).HasForeignKey(o => o.QuestionID).WillCascadeOnDelete(false);
        }
    }
}
