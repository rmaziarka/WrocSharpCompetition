namespace WrocSharpCompetition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestAnswers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AnsweringTime = c.DateTime(nullable: false),
                        AnsweringTimeOffset = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestAnswers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestAnswers", "TestId", "dbo.Tests");
            DropIndex("dbo.TestAnswers", new[] { "UserId" });
            DropIndex("dbo.TestAnswers", new[] { "TestId" });
            DropTable("dbo.TestAnswers");
        }
    }
}
