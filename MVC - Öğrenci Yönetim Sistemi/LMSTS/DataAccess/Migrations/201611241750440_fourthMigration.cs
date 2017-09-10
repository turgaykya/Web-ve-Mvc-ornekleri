namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topic", "DateOfCreation", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Topic", "DateOfLock", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topic", "DateOfLock", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Topic", "DateOfCreation", c => c.DateTime(storeType: "date"));
        }
    }
}
