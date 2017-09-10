namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginPropsAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "UserId", c => c.String());
            AddColumn("dbo.Employee", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Password");
            DropColumn("dbo.Employee", "UserId");
        }
    }
}
