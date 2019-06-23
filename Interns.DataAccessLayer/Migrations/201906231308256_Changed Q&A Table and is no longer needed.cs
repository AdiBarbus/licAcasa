namespace Interns.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedQATableandisnolongerneeded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Qas", "DomainId", "dbo.Domains");
            DropForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains");
            DropIndex("dbo.Qas", new[] { "SubDomainId" });
            DropIndex("dbo.Qas", new[] { "DomainId" });
            AddColumn("dbo.Questions", "SubDomainId", c => c.Int());
            AddColumn("dbo.Questions", "DomainId", c => c.Int());
            CreateIndex("dbo.Questions", "SubDomainId");
            CreateIndex("dbo.Questions", "DomainId");
            AddForeignKey("dbo.Questions", "DomainId", "dbo.Domains", "Id");
            AddForeignKey("dbo.Questions", "SubDomainId", "dbo.SubDomains", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.Questions", "DomainId", "dbo.Domains");
            DropIndex("dbo.Questions", new[] { "DomainId" });
            DropIndex("dbo.Questions", new[] { "SubDomainId" });
            DropColumn("dbo.Questions", "DomainId");
            DropColumn("dbo.Questions", "SubDomainId");
            CreateIndex("dbo.Qas", "DomainId");
            CreateIndex("dbo.Qas", "SubDomainId");
            AddForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.Qas", "DomainId", "dbo.Domains", "Id");
        }
    }
}
