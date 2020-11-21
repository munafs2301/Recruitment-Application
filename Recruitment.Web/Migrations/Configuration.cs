namespace Recruitment.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Recruitment.Domain.Entities;
    using Recruitment.Domain.Enums;
    using Recruitment.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Recruitment.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Recruitment.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                Email = "munaproject20@gmail.com",
                UserName = "munaproject20@gmail.com",
                EmailConfirmed = true

            };

            var result = UserManager.Create(user, "muna.12345.FS");

            if (result.Succeeded)
            {
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    UserManager.AddToRole(user.Id, "Admin");
                }
            }
                        
            // creating Creating User role   
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }


            context.Jobs.AddOrUpdate(x => x.JobId,
                new Job() {JobId = 1, Title = "Senior Software Developer- REMOTE OR RELOCATION TO CANADA", Company = "SOTI", Location = "Lagos",
                 Level = Level.Senior, Type = JobType.Fulltime, Salary = 800000, YearsExperienced = "5+", Description = "Senior level hands-on" +
                 " experience in software development & solution design preferably with product companies \n Demonstrable versatility in various front-end and back-end technologies, ideally JavaScript, HTML5, CSS3, AngularJS, NodeJS, REST APIs, JSON, WCF, Web API, Unity, LINQ\nExcellent understanding of unit test principles, multi-layer architecture, SOA principles and best development practices, as well as previous experience using OOD, Design Patterns, Data Modelling and Storage with well-known relational database (preferably SQL)"
                },
                new Job() {JobId = 2, Title = "Senior Software Engineer", Company = "Fair Money", Location = "Lagos",
                 Level = Level.Senior, Type = JobType.Fulltime, Salary = 700000, YearsExperienced = "5+", Description = "Senior level hands-on" +
                 " experience in software development & solution design preferably with product companies \n Demonstrable versatility in various front-end and back-end technologies, ideally JavaScript, HTML5, CSS3, AngularJS, NodeJS, REST APIs, JSON, WCF, Web API, Unity, LINQ\nExcellent understanding of unit test principles, multi-layer architecture, SOA principles and best development practices, as well as previous experience using OOD, Design Patterns, Data Modelling and Storage with well-known relational database (preferably SQL)"
                },                
                new Job() {JobId = 3, Title = "Junior Software Engineer", Company = " Dochase", Location = "Lagos",
                        Level = Level.Entry, Type = JobType.Fulltime, Salary = 100000, YearsExperienced = "1+", Description = @"A solution driven Fullstack Developer
                                Proficient in NodeJS,
                                                    ElasticSearch,
                                                    MongoDB,
                                                    MySql or Postgres,
                                                    React
                                Experienced in building multi tenancy apps
                                Knowledge of CI / CD" 
                    }, 
                new Job()
                    {
                        JobId = 4,
                        Title = "Java Software Developer at Byteworks Technology Solutions Limited",
                        Company = "ByteWorks Technology Solutions ",
                        Location = "Abuja",
                        Level = Level.Entry,
                        Type = JobType.Fulltime,
                        Salary = 70000,
                        YearsExperienced = "1+",
                        Description = @"Programming experience using relevant languages and relevant tool suites (C#, ASP,.NET, Angular)
                                Proficiency in Java
                                Experience in software development using agile practices, patterns and techniques SQL Server(Complex Stored Procedure, Query and Function) Object Oriented Programming Web application development
                                Proficiency in mobile application development(Android and iOS) is as added advantage."
                    },
                 new Job()
                    {
                        JobId = 5,
                        Title = "Frontend Software Engineer",
                        Company = "Pangaea ",
                        Location = "Lagos",
                        Level = Level.Entry,
                        Type = JobType.Fulltime,
                        Salary = 70000,
                        YearsExperienced = "2+",
                        Description = @"Strong command of HTML, CSS, Javascript is a must!
                                        Professional experience with React.js
                                        Strong command of javascript fundamentals (vanilla js, jquery)
                                        Strong command of asynchronous programming
                                        Familiarity with dependency management
                                        Strong proficiency with responsive design and media
                                        Collaborate in a fast-paced, team environment to push a lot of code."
                 },
                 
                 new Job()
                    {
                        JobId = 6,
                        Title = "NYSC Intern",
                        Company = "eHealth4everyone",
                        Location = "Abuja",
                        Level = Level.Entry,
                        Type = JobType.Internship,
                        Salary = 50000,
                        YearsExperienced = "1 - 3",
                        Description = @"Strong command of HTML, CSS, Javascript is a must!
                                        Professional experience with React.js
                                        Strong command of javascript fundamentals (vanilla js, jquery)
                                        Strong command of asynchronous programming
                                        Familiarity with dependency management
                                        Strong proficiency with responsive design and media
                                        Collaborate in a fast-paced, team environment to push a lot of code."
                 },
                 
                 new Job()
                    {
                        JobId = 7,
                        Title = "Product Marketing Manager",
                        Company = "Asset & Resource Management Holding Company (ARM HoldCo). ",
                        Location = "Lagos",
                        Level = Level.Senior,
                        Type = JobType.Fulltime,
                        Salary = 550000,
                        YearsExperienced = "4+",
                        Description = @"Develop actionable, data-driven insights to inform product and marketing strategy. Leverage marketing insights to better understand our customers and represent the voice of the user.
Work with visiting research teams to help them better understand the market and achieve their objectives.
Partner with cross-functional stakeholders including product, user experience, design, analytics, creative and leadership, to drive product roadmaps, strategy and execution.
Understand multiple dashboards, use the data to analyze product health and be able to use that information to influence direction on product and marketing.."
                 },
                 
                 new Job()
                    {
                        JobId = 8,
                        Title = "Product Marketer",
                        Company = "Asset & Resource Management Holding Company (ARM HoldCo). ",
                        Location = "Lagos",
                        Level = Level.Junior,
                        Type = JobType.Fulltime,
                        Salary = 100000,
                        YearsExperienced = "4+",
                        Description = @"Develop actionable, data-driven insights to inform product and marketing strategy. Leverage marketing insights to better understand our customers and represent the voice of the user.
Work with visiting research teams to help them better understand the market and achieve their objectives.
Partner with cross-functional stakeholders including product, user experience, design, analytics, creative and leadership, to drive product roadmaps, strategy and execution.
Understand multiple dashboards, use the data to analyze product health and be able to use that information to influence direction on product and marketing.."
                 },
                  new Job()
                    {
                        JobId = 9,
                        Title = "Lead UI/UX & Creative Designer",
                        Company = "Asset & Resource Management Holding Company (ARM HoldCo). ",
                        Location = "Johannesburg, South Africa",
                        Level = Level.Intermediate,
                        Type = JobType.Fulltime,
                        Salary = 200000,
                        YearsExperienced = "4+",
                        Description = @"Requirements Gathering Liaise with client functions to establish their communication needs, requirements, and audiences to guide the direction of the creative solution.
Design Direction Set direction for design briefs, based on the requirements of client functions, schedule project implementation, and define constraints.
Development of Creative Design Solutions Work with a wide range of media (e.g. photography, graphics) in developing new design concepts, graphics, and layouts for creative briefs, using graphic design software, and obtaining the sign-off of client functions for final adoption of designs.
UI/UX have a minimum working knowledge of practical User interface design with a focus on financial platforms."
                  },
                  
                  new Job()
                    {
                        JobId = 10,
                        Title = "Product Designer",
                        Company = "Venture Garden Group ",
                        Location = "Ikeja, NG",
                        Level = Level.Senior,
                        Type = JobType.Fulltime,
                        Salary = 120000,
                        YearsExperienced = "4+",
                        Description = @"Collaborate with the product and engineering teams to ensure optimal product, tech and design collaboration.
Comfortably scoping and facilitating user research and usability testing; to deepen customer understanding and quickly iterate designs to better meet our customer’s needs
Develop wireframes, interactive prototypes, specification and other design documents to communicate design ideas and intent to team/s."
                  }

                );
        }
    }
    }

