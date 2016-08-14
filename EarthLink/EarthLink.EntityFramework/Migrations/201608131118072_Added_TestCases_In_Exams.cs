namespace EarthLink.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_TestCases_In_Exams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpTestCases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        Input = c.String(nullable: false),
                        ExpectedOutput = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpExams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpTestCases", "ExamId", "dbo.AbpExams");
            DropIndex("dbo.AbpTestCases", new[] { "ExamId" });
            DropTable("dbo.AbpTestCases");
        }
    }
}
