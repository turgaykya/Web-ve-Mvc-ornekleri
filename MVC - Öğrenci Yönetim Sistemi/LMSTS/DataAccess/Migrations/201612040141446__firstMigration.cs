namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _firstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "EducationGrouoStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Education_Group_Student", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Education_Group_Student", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Student", "EducationGrouoStatus");
        }
    }
}
