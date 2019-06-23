namespace Interns.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedDomainIdToSubDomain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubDomains", "Domain_Id", "dbo.Domains");
            DropIndex("dbo.SubDomains", new[] { "Domain_Id" });
            RenameColumn(table: "dbo.SubDomains", name: "Domain_Id", newName: "DomainId");
            AlterColumn("dbo.SubDomains", "DomainId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubDomains", "DomainId");
            AddForeignKey("dbo.SubDomains", "DomainId", "dbo.Domains", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDomains", "DomainId", "dbo.Domains");
            DropIndex("dbo.SubDomains", new[] { "DomainId" });
            AlterColumn("dbo.SubDomains", "DomainId", c => c.Int());
            RenameColumn(table: "dbo.SubDomains", name: "DomainId", newName: "Domain_Id");
            CreateIndex("dbo.SubDomains", "Domain_Id");
            AddForeignKey("dbo.SubDomains", "Domain_Id", "dbo.Domains", "Id");
        }
    }
}
