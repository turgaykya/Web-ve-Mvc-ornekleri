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
    public class QuestionMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Question> questionConfig = modelBuilder.Entity<Question>();

            questionConfig.HasKey(q => q.Id);
            questionConfig.Property(q => q.Point).IsRequired().HasColumnType("smallint");
            questionConfig.Property(q => q.Text).IsRequired().HasColumnType("varchar").HasMaxLength(2000);

            questionConfig.HasRequired(q => q.Subject).WithMany(q => q.Questions).HasForeignKey(q => q.SubjectID).WillCascadeOnDelete(false);
        }
    }
}
