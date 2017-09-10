namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        QuestionID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        OptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionID, t.StudentID })
                .ForeignKey("dbo.Option", t => t.OptionID)
                .ForeignKey("dbo.Question", t => t.QuestionID)
                .ForeignKey("dbo.Student", t => t.StudentID)
                .Index(t => t.QuestionID)
                .Index(t => t.StudentID)
                .Index(t => t.OptionID);
            
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 2000, unicode: false),
                        TrueAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        Point = c.Short(nullable: false),
                        Text = c.String(nullable: false, maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        EducationGroupID = c.Int(nullable: false),
                        DateOfCreation = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationGroup", t => t.EducationGroupID)
                .Index(t => t.EducationGroupID);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        Document = c.String(nullable: false, maxLength: 4000),
                        DateOfCreation = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.EducationGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        DateOfCreation = c.DateTime(storeType: "date"),
                        DateOfEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainer", t => t.TrainerID)
                .Index(t => t.TrainerID);
            
            CreateTable(
                "dbo.Education_Group_Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        EducationGroupID = c.Int(nullable: false),
                        DateOfJoin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.EducationGroupID })
                .ForeignKey("dbo.EducationGroup", t => t.EducationGroupID)
                .ForeignKey("dbo.Student", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.EducationGroupID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        EducationBranchID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        IsOnline = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateOfRegistration = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationBranch", t => t.EducationBranchID)
                .ForeignKey("dbo.Gender", t => t.GenderID)
                .ForeignKey("dbo.Login", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.EducationBranchID)
                .Index(t => t.GenderID);
            
            CreateTable(
                "dbo.EducationBranch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        BranchID = c.Int(nullable: false),
                        TitleID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        IsOnline = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateOfRegistration = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchID)
                .ForeignKey("dbo.Gender", t => t.GenderID)
                .ForeignKey("dbo.Login", t => t.Id)
                .ForeignKey("dbo.Title", t => t.TitleID)
                .Index(t => t.Id)
                .Index(t => t.BranchID)
                .Index(t => t.TitleID)
                .Index(t => t.GenderID);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        TrainerID = c.Int(nullable: false),
                        EducationGroupID = c.Int(nullable: false),
                        Document = c.String(maxLength: 300),
                        DateOfAssingment = c.DateTime(nullable: false, storeType: "date"),
                        Deadline = c.DateTime(nullable: false, storeType: "date"),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationGroup", t => t.EducationGroupID)
                .ForeignKey("dbo.Subject", t => t.SubjectID)
                .ForeignKey("dbo.Trainer", t => t.TrainerID)
                .Index(t => t.SubjectID)
                .Index(t => t.TrainerID)
                .Index(t => t.EducationGroupID);
            
            CreateTable(
                "dbo.HomeworkDelivery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeworkID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        DateOfDelivery = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Homework", t => t.HomeworkID)
                .ForeignKey("dbo.Student", t => t.StudentID)
                .Index(t => t.HomeworkID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.HomeworkReturn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeworkDeliveryID = c.Int(nullable: false),
                        EvaluationPoint = c.Short(),
                        ReturnTypeID = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HomeworkDelivery", t => t.HomeworkDeliveryID)
                .ForeignKey("dbo.ReturnType", t => t.ReturnTypeID)
                .Index(t => t.HomeworkDeliveryID)
                .Index(t => t.ReturnTypeID);
            
            CreateTable(
                "dbo.ReturnType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Mail = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 36),
                        CitizenNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        DateOfComment = c.DateTime(nullable: false, storeType: "date"),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Login", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Topic", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.TopicID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EducationGroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Head = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(nullable: false, maxLength: 2000, unicode: false),
                        DateOfCreation = c.DateTime(storeType: "date"),
                        DateOfLock = c.DateTime(nullable: false, storeType: "date"),
                        Hit = c.Short(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationGroup", t => t.EducationGroupID)
                .ForeignKey("dbo.Login", t => t.UserID)
                .Index(t => t.EducationGroupID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.LogPage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 2000),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        UserID = c.Int(nullable: false),
                        DateOfPageOpen = c.DateTime(nullable: false, storeType: "date"),
                        DateOfPageClose = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Login", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.LogSystemLogin",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        DateOfSystemLogin = c.DateTime(nullable: false, storeType: "date"),
                        DateOfSystemLogout = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => new { t.UserID, t.DateOfSystemLogin })
                .ForeignKey("dbo.Login", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.MessageGroup_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        MessageGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MessageGroup", t => t.MessageGroupID)
                .ForeignKey("dbo.Login", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.MessageGroupID);
            
            CreateTable(
                "dbo.MessageGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        DateOfCreation = c.DateTime(nullable: false, storeType: "date"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 2000, unicode: false),
                        UserID = c.Int(nullable: false),
                        MessageGroupID = c.Int(nullable: false),
                        DateOfSend = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MessageGroup", t => t.MessageGroupID)
                .ForeignKey("dbo.Login", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.MessageGroupID);
            
            CreateTable(
                "dbo.Title",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Answer", "QuestionID", "dbo.Question");
            DropForeignKey("dbo.Answer", "OptionID", "dbo.Option");
            DropForeignKey("dbo.Option", "QuestionID", "dbo.Question");
            DropForeignKey("dbo.Question", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Subject", "EducationGroupID", "dbo.EducationGroup");
            DropForeignKey("dbo.EducationGroup", "TrainerID", "dbo.Trainer");
            DropForeignKey("dbo.Education_Group_Student", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Student", "Id", "dbo.Login");
            DropForeignKey("dbo.Student", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.Trainer", "TitleID", "dbo.Title");
            DropForeignKey("dbo.Trainer", "Id", "dbo.Login");
            DropForeignKey("dbo.MessageGroup_User", "UserID", "dbo.Login");
            DropForeignKey("dbo.MessageGroup_User", "MessageGroupID", "dbo.MessageGroup");
            DropForeignKey("dbo.Message", "UserID", "dbo.Login");
            DropForeignKey("dbo.Message", "MessageGroupID", "dbo.MessageGroup");
            DropForeignKey("dbo.LogSystemLogin", "UserID", "dbo.Login");
            DropForeignKey("dbo.LogPage", "UserID", "dbo.Login");
            DropForeignKey("dbo.Comment", "TopicID", "dbo.Topic");
            DropForeignKey("dbo.Topic", "UserID", "dbo.Login");
            DropForeignKey("dbo.Topic", "EducationGroupID", "dbo.EducationGroup");
            DropForeignKey("dbo.Comment", "UserID", "dbo.Login");
            DropForeignKey("dbo.Homework", "TrainerID", "dbo.Trainer");
            DropForeignKey("dbo.Homework", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.HomeworkDelivery", "StudentID", "dbo.Student");
            DropForeignKey("dbo.HomeworkReturn", "ReturnTypeID", "dbo.ReturnType");
            DropForeignKey("dbo.HomeworkReturn", "HomeworkDeliveryID", "dbo.HomeworkDelivery");
            DropForeignKey("dbo.HomeworkDelivery", "HomeworkID", "dbo.Homework");
            DropForeignKey("dbo.Homework", "EducationGroupID", "dbo.EducationGroup");
            DropForeignKey("dbo.Trainer", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.Trainer", "BranchID", "dbo.Branch");
            DropForeignKey("dbo.Student", "EducationBranchID", "dbo.EducationBranch");
            DropForeignKey("dbo.Education_Group_Student", "EducationGroupID", "dbo.EducationGroup");
            DropForeignKey("dbo.Content", "SubjectID", "dbo.Subject");
            DropIndex("dbo.Message", new[] { "MessageGroupID" });
            DropIndex("dbo.Message", new[] { "UserID" });
            DropIndex("dbo.MessageGroup_User", new[] { "MessageGroupID" });
            DropIndex("dbo.MessageGroup_User", new[] { "UserID" });
            DropIndex("dbo.LogSystemLogin", new[] { "UserID" });
            DropIndex("dbo.LogPage", new[] { "UserID" });
            DropIndex("dbo.Topic", new[] { "UserID" });
            DropIndex("dbo.Topic", new[] { "EducationGroupID" });
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropIndex("dbo.Comment", new[] { "TopicID" });
            DropIndex("dbo.HomeworkReturn", new[] { "ReturnTypeID" });
            DropIndex("dbo.HomeworkReturn", new[] { "HomeworkDeliveryID" });
            DropIndex("dbo.HomeworkDelivery", new[] { "StudentID" });
            DropIndex("dbo.HomeworkDelivery", new[] { "HomeworkID" });
            DropIndex("dbo.Homework", new[] { "EducationGroupID" });
            DropIndex("dbo.Homework", new[] { "TrainerID" });
            DropIndex("dbo.Homework", new[] { "SubjectID" });
            DropIndex("dbo.Trainer", new[] { "GenderID" });
            DropIndex("dbo.Trainer", new[] { "TitleID" });
            DropIndex("dbo.Trainer", new[] { "BranchID" });
            DropIndex("dbo.Trainer", new[] { "Id" });
            DropIndex("dbo.Student", new[] { "GenderID" });
            DropIndex("dbo.Student", new[] { "EducationBranchID" });
            DropIndex("dbo.Student", new[] { "Id" });
            DropIndex("dbo.Education_Group_Student", new[] { "EducationGroupID" });
            DropIndex("dbo.Education_Group_Student", new[] { "StudentID" });
            DropIndex("dbo.EducationGroup", new[] { "TrainerID" });
            DropIndex("dbo.Content", new[] { "SubjectID" });
            DropIndex("dbo.Subject", new[] { "EducationGroupID" });
            DropIndex("dbo.Question", new[] { "SubjectID" });
            DropIndex("dbo.Option", new[] { "QuestionID" });
            DropIndex("dbo.Answer", new[] { "OptionID" });
            DropIndex("dbo.Answer", new[] { "StudentID" });
            DropIndex("dbo.Answer", new[] { "QuestionID" });
            DropTable("dbo.Title");
            DropTable("dbo.Message");
            DropTable("dbo.MessageGroup");
            DropTable("dbo.MessageGroup_User");
            DropTable("dbo.LogSystemLogin");
            DropTable("dbo.LogPage");
            DropTable("dbo.Topic");
            DropTable("dbo.Comment");
            DropTable("dbo.Login");
            DropTable("dbo.ReturnType");
            DropTable("dbo.HomeworkReturn");
            DropTable("dbo.HomeworkDelivery");
            DropTable("dbo.Homework");
            DropTable("dbo.Branch");
            DropTable("dbo.Trainer");
            DropTable("dbo.Gender");
            DropTable("dbo.EducationBranch");
            DropTable("dbo.Student");
            DropTable("dbo.Education_Group_Student");
            DropTable("dbo.EducationGroup");
            DropTable("dbo.Content");
            DropTable("dbo.Subject");
            DropTable("dbo.Question");
            DropTable("dbo.Option");
            DropTable("dbo.Answer");
        }
    }
}
