namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TopicTestHeadNvarchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topic", "Head", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Topic", "Description", c => c.String(nullable: false, maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topic", "Description", c => c.String(nullable: false, maxLength: 2000, unicode: false));
            AlterColumn("dbo.Topic", "Head", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
