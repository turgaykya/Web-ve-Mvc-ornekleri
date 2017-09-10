namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentDateGuncellemesi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comment", "DateOfComment", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comment", "DateOfComment", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
