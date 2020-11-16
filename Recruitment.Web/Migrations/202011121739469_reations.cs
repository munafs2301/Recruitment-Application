namespace Recruitment.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "JobId", c => c.Int(nullable: false));
            CreateIndex("dbo.Applicants", "JobId");
            AddForeignKey("dbo.Applicants", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "JobId", "dbo.Jobs");
            DropIndex("dbo.Applicants", new[] { "JobId" });
            DropColumn("dbo.Applicants", "JobId");
        }
    }
}
