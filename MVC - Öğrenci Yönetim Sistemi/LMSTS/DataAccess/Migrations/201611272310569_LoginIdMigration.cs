namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginIdMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Login", new[] { "Id" });
            CreateIndex("dbo.Student", "Id");
            CreateIndex("dbo.Trainer", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Trainer", new[] { "Id" });
            DropIndex("dbo.Student", new[] { "Id" });
            CreateIndex("dbo.Login", "Id");
        }
    }
}
