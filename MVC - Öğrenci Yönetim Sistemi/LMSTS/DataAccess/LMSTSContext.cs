using _01_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class LMSTSContext:DbContext
    {
        public LMSTSContext():base("LMSTSProject")
        {

        }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Education_Group_Student> EducationGroup_Student { get; set; }
        public DbSet<EducationBranch> EducationBranch { get; set; }
        public DbSet<EducationGroup> EducationGroup { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<HomeworkDelivery> HomeworkDelivery { get; set; }
        public DbSet<HomeworkReturn> HomeworkReturn { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<LogPage> LogPage { get; set; }
        public DbSet<LogSystemLogin> LogSystemLogin { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageGroup> MessageGroup { get; set; }
        public DbSet<MessageGroup_User> MessageGroup_User { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<ReturnType> ReturnType { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Mapping.AnswerMapping.Map(modelBuilder);
            Mapping.BranchMapping.Map(modelBuilder);
            Mapping.CommentMapping.Map(modelBuilder);
            Mapping.ContentMapping.Map(modelBuilder);
            Mapping.EducationBranchMapping.Map(modelBuilder);
            Mapping.EducationGroupMapping.Map(modelBuilder);
            Mapping.Education_Group_StudentMapping.Map(modelBuilder);
            Mapping.GenderMapping.Map(modelBuilder);
            Mapping.HomeworkDeliveryMapping.Map(modelBuilder);
            Mapping.HomeworkMapping.Map(modelBuilder);
            Mapping.HomeworkReturnMapping.Map(modelBuilder);
            Mapping.LoginMapping.Map(modelBuilder);
            Mapping.LogPageMapping.Map(modelBuilder);
            Mapping.LogSystemLoginMapping.Map(modelBuilder);
            Mapping.MessageGroupMapping.Map(modelBuilder);
            Mapping.MessageGroup_UserMapping.Map(modelBuilder);
            Mapping.MessageMapping.Map(modelBuilder);
            Mapping.OptionMapping.Map(modelBuilder);
            Mapping.QuestionMapping.Map(modelBuilder);
            Mapping.ReturnTypeMapping.Map(modelBuilder);
            Mapping.StudentMapping.Map(modelBuilder);
            Mapping.SubjectMapping.Map(modelBuilder);
            Mapping.TitleMapping.Map(modelBuilder);
            Mapping.TopicMapping.Map(modelBuilder);
            Mapping.TrainerMapping.Map(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
