namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMicration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Login", "CitizenNumber", c => c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Login", "CitizenNumber", c => c.Int(nullable: false));
        }
    }
}
