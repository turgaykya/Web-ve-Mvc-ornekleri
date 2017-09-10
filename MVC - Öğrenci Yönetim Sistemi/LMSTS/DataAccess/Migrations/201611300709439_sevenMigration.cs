namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sevenMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Education_Group_Student", "EducationGroupID", "dbo.EducationGroup");
            DropForeignKey("dbo.Education_Group_Student", "StudentID", "dbo.Student");
            CreateTable(
                "dbo.StudentEducationGroup",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        EducationGroup_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.EducationGroup_Id })
                .ForeignKey("dbo.Student", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.EducationGroup", t => t.EducationGroup_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.EducationGroup_Id);
            
            AddForeignKey("dbo.Education_Group_Student", "EducationGroupID", "dbo.EducationGroup", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Education_Group_Student", "StudentID", "dbo.Student", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Education_Group_Student", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Education_Group_Student", "EducationGroupID", "dbo.EducationGroup");
            DropForeignKey("dbo.StudentEducationGroup", "EducationGroup_Id", "dbo.EducationGroup");
            DropForeignKey("dbo.StudentEducationGroup", "Student_Id", "dbo.Student");
            DropIndex("dbo.StudentEducationGroup", new[] { "EducationGroup_Id" });
            DropIndex("dbo.StudentEducationGroup", new[] { "Student_Id" });
            DropTable("dbo.StudentEducationGroup");
            AddForeignKey("dbo.Education_Group_Student", "StudentID", "dbo.Student", "Id");
            AddForeignKey("dbo.Education_Group_Student", "EducationGroupID", "dbo.EducationGroup", "Id");
        }
    }
}
