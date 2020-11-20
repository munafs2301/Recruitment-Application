namespace Recruitment.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "ApplicationStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "UserId", c => c.String());
            AddColumn("dbo.Applicants", "ImagePath", c => c.String());
            AddColumn("dbo.Applicants", "ResumePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "ResumePath");
            DropColumn("dbo.Applicants", "ImagePath");
            DropColumn("dbo.Applicants", "UserId");
            DropColumn("dbo.Applicants", "ApplicationStatus");
        }
    }
}
