namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EducationGroup", "DateOfCreation", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.EducationGroup", "DateOfEnd", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EducationGroup", "DateOfEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EducationGroup", "DateOfCreation", c => c.DateTime(storeType: "date"));
        }
    }
}
