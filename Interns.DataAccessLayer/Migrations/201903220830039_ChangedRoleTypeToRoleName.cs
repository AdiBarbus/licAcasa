namespace Interns.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRoleTypeToRoleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Roles", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Type", c => c.String(nullable: false));
            DropColumn("dbo.Roles", "Name");
        }
    }
}
