namespace Recruitment.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedFileData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicants", "JobId", "dbo.Jobs");
            DropIndex("dbo.Applicants", new[] { "JobId" });
            AddColumn("dbo.Applicants", "JobTitle", c => c.String());
            DropColumn("dbo.Applicants", "Image");
            DropColumn("dbo.Applicants", "ImageMimeType");
            DropColumn("dbo.Applicants", "CV");
            DropColumn("dbo.Applicants", "CVMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicants", "CVMimeType", c => c.String());
            AddColumn("dbo.Applicants", "CV", c => c.Binary());
            AddColumn("dbo.Applicants", "ImageMimeType", c => c.String());
            AddColumn("dbo.Applicants", "Image", c => c.Binary());
            DropColumn("dbo.Applicants", "JobTitle");
            CreateIndex("dbo.Applicants", "JobId");
            AddForeignKey("dbo.Applicants", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
    }
}
