namespace Interns.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        County = c.String(),
                        Street = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete:true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Phone = c.String(),
                        University = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Advertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        City = c.String(nullable: false),
                        Domain_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Domains", t => t.Domain_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Domain_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Qas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubDomains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Advertises", "User_Id", "dbo.Users");
            //DropForeignKey("dbo.Advertises", "Domain_Id", "dbo.Domains");
            //DropForeignKey("dbo.Addresses", "UserId", "dbo.Users");
            //DropIndex("dbo.Advertises", new[] { "User_Id" });
            //DropIndex("dbo.Advertises", new[] { "Domain_Id" });
            //DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.SubDomains");
            DropTable("dbo.Roles");
            DropTable("dbo.Qas");
            DropTable("dbo.Domains");
            DropTable("dbo.Advertises");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
