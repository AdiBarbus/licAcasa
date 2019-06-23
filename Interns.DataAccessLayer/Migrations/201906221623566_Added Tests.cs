namespace Interns.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises");
            DropIndex("dbo.Qas", new[] { "AdvertiseId" });
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ans = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quest = c.String(),
                        TestId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Qas", "DomainId", c => c.Int());
            CreateIndex("dbo.Qas", "DomainId");
            AddForeignKey("dbo.Qas", "DomainId", "dbo.Domains", "Id");
            DropColumn("dbo.Qas", "AdvertiseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Qas", "AdvertiseId", c => c.Int());
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Qas", "DomainId", "dbo.Domains");
            DropIndex("dbo.Questions", new[] { "TestId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Qas", new[] { "DomainId" });
            DropColumn("dbo.Qas", "DomainId");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            CreateIndex("dbo.Qas", "AdvertiseId");
            AddForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises", "Id");
        }
    }
}
