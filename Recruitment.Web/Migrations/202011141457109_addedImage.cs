namespace Recruitment.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "Image", c => c.Binary());
            AddColumn("dbo.Applicants", "ImageContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "ImageContentType");
            DropColumn("dbo.Applicants", "Image");
        }
    }
}
