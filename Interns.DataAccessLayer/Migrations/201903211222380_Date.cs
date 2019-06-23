namespace Interns.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advertises", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Advertises", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advertises", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Advertises", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
