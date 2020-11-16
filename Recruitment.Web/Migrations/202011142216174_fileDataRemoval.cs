namespace Recruitment.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileDataRemoval : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applicants", "Image");
            DropColumn("dbo.Applicants", "ImageContentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicants", "ImageContentType", c => c.String());
            AddColumn("dbo.Applicants", "Image", c => c.Binary());
        }
    }
}
