namespace Interns.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class collections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role_Id", c => c.Int());
            AddColumn("dbo.Advertises", "SubDomain_Id", c => c.Int());
            AddColumn("dbo.Qas", "SubDomain_Id", c => c.Int());
            AddColumn("dbo.Qas", "Advertise_Id", c => c.Int());
            AddColumn("dbo.SubDomains", "Domain_Id", c => c.Int());
            CreateIndex("dbo.Users", "Role_Id");
            CreateIndex("dbo.Advertises", "SubDomain_Id");
            CreateIndex("dbo.SubDomains", "Domain_Id");
            CreateIndex("dbo.Qas", "SubDomain_Id");
            CreateIndex("dbo.Qas", "Advertise_Id");
            AddForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.Qas", "SubDomain_Id", "dbo.SubDomains", "Id",cascadeDelete:true);
            AddForeignKey("dbo.SubDomains", "Domain_Id", "dbo.Domains", "Id", cascadeDelete:true);
            AddForeignKey("dbo.Qas", "Advertise_Id", "dbo.Advertises", "Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "LastName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Qas", "Advertise_Id", "dbo.Advertises");
            DropForeignKey("dbo.SubDomains", "Domain_Id", "dbo.Domains");
            DropForeignKey("dbo.Qas", "SubDomain_Id", "dbo.SubDomains");
            DropForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains");
            DropIndex("dbo.Qas", new[] { "Advertise_Id" });
            DropIndex("dbo.Qas", new[] { "SubDomain_Id" });
            DropIndex("dbo.SubDomains", new[] { "Domain_Id" });
            DropIndex("dbo.Advertises", new[] { "SubDomain_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropColumn("dbo.SubDomains", "Domain_Id");
            DropColumn("dbo.Qas", "Advertise_Id");
            DropColumn("dbo.Qas", "SubDomain_Id");
            DropColumn("dbo.Advertises", "SubDomain_Id");
            DropColumn("dbo.Users", "Role_Id");
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Users", "UserName");
        }
    }
}
