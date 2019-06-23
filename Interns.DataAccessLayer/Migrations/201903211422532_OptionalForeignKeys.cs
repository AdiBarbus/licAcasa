namespace Interns.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertises", "DomainId", "dbo.Domains");
            DropForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises");
            DropForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.Advertises", "UserId", "dbo.Users");
            DropForeignKey("dbo.SubDomains", "DomainId", "dbo.Domains");
            DropForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains");
            DropIndex("dbo.Advertises", new[] { "UserId" });
            DropIndex("dbo.Advertises", new[] { "DomainId" });
            DropIndex("dbo.Advertises", new[] { "SubDomainId" });
            DropIndex("dbo.SubDomains", new[] { "DomainId" });
            DropIndex("dbo.Qas", new[] { "SubDomainId" });
            DropIndex("dbo.Qas", new[] { "AdvertiseId" });
            AlterColumn("dbo.Advertises", "UserId", c => c.Int());
            AlterColumn("dbo.Advertises", "DomainId", c => c.Int());
            AlterColumn("dbo.Advertises", "SubDomainId", c => c.Int());
            AlterColumn("dbo.SubDomains", "DomainId", c => c.Int());
            AlterColumn("dbo.Qas", "SubDomainId", c => c.Int());
            AlterColumn("dbo.Qas", "AdvertiseId", c => c.Int());
            CreateIndex("dbo.Advertises", "UserId");
            CreateIndex("dbo.Advertises", "DomainId");
            CreateIndex("dbo.Advertises", "SubDomainId");
            CreateIndex("dbo.SubDomains", "DomainId");
            CreateIndex("dbo.Qas", "SubDomainId");
            CreateIndex("dbo.Qas", "AdvertiseId");
            AddForeignKey("dbo.Advertises", "DomainId", "dbo.Domains", "Id");
            AddForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises", "Id");
            AddForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.Advertises", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.SubDomains", "DomainId", "dbo.Domains", "Id");
            AddForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.SubDomains", "DomainId", "dbo.Domains");
            DropForeignKey("dbo.Advertises", "UserId", "dbo.Users");
            DropForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises");
            DropForeignKey("dbo.Advertises", "DomainId", "dbo.Domains");
            DropIndex("dbo.Qas", new[] { "AdvertiseId" });
            DropIndex("dbo.Qas", new[] { "SubDomainId" });
            DropIndex("dbo.SubDomains", new[] { "DomainId" });
            DropIndex("dbo.Advertises", new[] { "SubDomainId" });
            DropIndex("dbo.Advertises", new[] { "DomainId" });
            DropIndex("dbo.Advertises", new[] { "UserId" });
            AlterColumn("dbo.Qas", "AdvertiseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Qas", "SubDomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.SubDomains", "DomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Advertises", "SubDomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Advertises", "DomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Advertises", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Qas", "AdvertiseId");
            CreateIndex("dbo.Qas", "SubDomainId");
            CreateIndex("dbo.SubDomains", "DomainId");
            CreateIndex("dbo.Advertises", "SubDomainId");
            CreateIndex("dbo.Advertises", "DomainId");
            CreateIndex("dbo.Advertises", "UserId");
            AddForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubDomains", "DomainId", "dbo.Domains", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Advertises", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Advertises", "DomainId", "dbo.Domains", "Id", cascadeDelete: true);
        }
    }
}
