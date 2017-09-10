namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Student", new[] { "Id" });
            DropIndex("dbo.Trainer", new[] { "Id" });
            CreateIndex("dbo.Login", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Login", new[] { "Id" });
            CreateIndex("dbo.Trainer", "Id");
            CreateIndex("dbo.Student", "Id");
        }
    }
}
