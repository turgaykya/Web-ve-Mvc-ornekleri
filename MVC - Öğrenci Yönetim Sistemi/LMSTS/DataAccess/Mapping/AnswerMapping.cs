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
    public class AnswerMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
           EntityTypeConfiguration<Answer> answerConfig = modelBuilder.Entity<Answer>();

            answerConfig.HasKey(x => new { x.QuestionID, x.StudentID });

            answerConfig.HasRequired(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x =>
              x.QuestionID)
                .WillCascadeOnDelete(false);
            answerConfig.HasRequired(x => x.Student).WithMany(x => x.Answers).HasForeignKey(x =>     x.StudentID).WillCascadeOnDelete(false);
            answerConfig.HasRequired(x => x.Option).WithMany(x => x.Answers).HasForeignKey(x =>  x.OptionID).WillCascadeOnDelete(false);

        }
    }
}
