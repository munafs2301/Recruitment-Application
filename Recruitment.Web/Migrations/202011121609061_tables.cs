namespace Recruitment.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ApplicantId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        Image = c.Binary(),
                        ImageMimeType = c.String(),
                        CV = c.Binary(),
                        CVMimeType = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Level = c.Int(nullable: false),
                        Location = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Company = c.String(),
                        YearsExperienced = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jobs");
            DropTable("dbo.Applicants");
        }
    }
}
