namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hatalıprojeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Education_Group_Student", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Education_Group_Student", "Status");
        }
    }
}
