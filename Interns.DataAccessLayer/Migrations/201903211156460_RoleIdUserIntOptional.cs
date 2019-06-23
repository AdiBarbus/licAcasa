namespace Interns.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleIdUserIntOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertises", "Domain_Id", "dbo.Domains");
            DropForeignKey("dbo.QAs", "Advertise_Id", "dbo.Advertises");
            DropForeignKey("dbo.Advertises", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains");
            DropForeignKey("dbo.QAs", "SubDomain_Id", "dbo.SubDomains");
            DropIndex("dbo.Advertises", new[] { "SubDomain_Id" });
            DropIndex("dbo.Advertises", new[] { "Domain_Id" });
            DropIndex("dbo.Advertises", new[] { "User_Id" });
            DropIndex("dbo.Qas", new[] { "SubDomain_Id" });
            DropIndex("dbo.Qas", new[] { "Advertise_Id" });
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleId");
            RenameColumn(table: "dbo.Advertises", name: "Domain_Id", newName: "DomainId");
            RenameColumn(table: "dbo.Qas", name: "Advertise_Id", newName: "AdvertiseId");
            RenameColumn(table: "dbo.Advertises", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Advertises", name: "SubDomain_Id", newName: "SubDomainId");
            RenameColumn(table: "dbo.Qas", name: "SubDomain_Id", newName: "SubDomainId");
            RenameIndex(table: "dbo.Users", name: "IX_Role_Id", newName: "IX_RoleId");
            AddColumn("dbo.Users", "PasswordSalt", c => c.String());
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Advertises", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Advertises", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Advertises", "SubDomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Advertises", "DomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Advertises", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Qas", "SubDomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Qas", "AdvertiseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advertises", "UserId");
            CreateIndex("dbo.Advertises", "DomainId");
            CreateIndex("dbo.Advertises", "SubDomainId");
            CreateIndex("dbo.Qas", "SubDomainId");
            CreateIndex("dbo.Qas", "AdvertiseId");
            AddForeignKey("dbo.Advertises", "DomainId", "dbo.Domains", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Advertises", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.Advertises", "UserId", "dbo.Users");
            DropForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises");
            DropForeignKey("dbo.Advertises", "DomainId", "dbo.Domains");
            DropIndex("dbo.Qas", new[] { "AdvertiseId" });
            DropIndex("dbo.Qas", new[] { "SubDomainId" });
            DropIndex("dbo.Advertises", new[] { "SubDomainId" });
            DropIndex("dbo.Advertises", new[] { "DomainId" });
            DropIndex("dbo.Advertises", new[] { "UserId" });
            AlterColumn("dbo.Qas", "AdvertiseId", c => c.Int());
            AlterColumn("dbo.Qas", "SubDomainId", c => c.Int());
            AlterColumn("dbo.Advertises", "UserId", c => c.Int());
            AlterColumn("dbo.Advertises", "DomainId", c => c.Int());
            AlterColumn("dbo.Advertises", "SubDomainId", c => c.Int());
            AlterColumn("dbo.Advertises", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Advertises", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "CreateDate");
            DropColumn("dbo.Users", "PasswordSalt");
            RenameIndex(table: "dbo.Users", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameColumn(table: "dbo.Qas", name: "SubDomainId", newName: "SubDomain_Id");
            RenameColumn(table: "dbo.Advertises", name: "SubDomainId", newName: "SubDomain_Id");
            RenameColumn(table: "dbo.Advertises", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Qas", name: "AdvertiseId", newName: "Advertise_Id");
            RenameColumn(table: "dbo.Advertises", name: "DomainId", newName: "Domain_Id");
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_Id");
            CreateIndex("dbo.Qas", "Advertise_Id");
            CreateIndex("dbo.Qas", "SubDomain_Id");
            CreateIndex("dbo.Advertises", "User_Id");
            CreateIndex("dbo.Advertises", "Domain_Id");
            CreateIndex("dbo.Advertises", "SubDomain_Id");
            AddForeignKey("dbo.QAs", "SubDomain_Id", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.Advertises", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.QAs", "Advertise_Id", "dbo.Advertises", "Id");
            AddForeignKey("dbo.Advertises", "Domain_Id", "dbo.Domains", "Id");
        }
    }
}
