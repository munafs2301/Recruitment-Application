using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recruitment.Domain.Entities;
using Recruitment.Domain.Enums;
using Recruitment.Domain.Interfaces;
using Recruitment.Web;
using Recruitment.Web.Controllers;

namespace Recruitment.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            Mock<IJobRepository> mock = new Mock<IJobRepository>();
            mock.Setup(m => m.Jobs).Returns(new Job[]
            {
                new Job() {JobId = 1, Title = "Senior Software Developer- REMOTE OR RELOCATION TO CANADA", Company = "SOTI", Location = "Lagos",
                 Level = Level.Senior, Type = JobType.Fulltime, Salary = 800000, YearsExperienced = "5+", Description = "Senior level hands-on" +
                 " experience in software development & solution design preferably with product companies \n Demonstrable versatility in various front-end and back-end technologies, ideally JavaScript, HTML5, CSS3, AngularJS, NodeJS, REST APIs, JSON, WCF, Web API, Unity, LINQ\nExcellent understanding of unit test principles, multi-layer architecture, SOA principles and best development practices, as well as previous experience using OOD, Design Patterns, Data Modelling and Storage with well-known relational database (preferably SQL)"
                },
                new Job() {JobId = 2, Title = "Senior Software Engineer", Company = "Fair Money", Location = "Lagos",
                 Level = Level.Senior, Type = JobType.Fulltime, Salary = 700000, YearsExperienced = "5+", Description = "Senior level hands-on" +
                 " experience in software development & solution design preferably with product companies \n Demonstrable versatility in various front-end and back-end technologies, ideally JavaScript, HTML5, CSS3, AngularJS, NodeJS, REST APIs, JSON, WCF, Web API, Unity, LINQ\nExcellent understanding of unit test principles, multi-layer architecture, SOA principles and best development practices, as well as previous experience using OOD, Design Patterns, Data Modelling and Storage with well-known relational database (preferably SQL)"
                },
                new Job() {JobId = 3, Title = "Junior Software Engineer", Company = " Dochase", Location = "Lagos",
                        Level = Level.Entry, Type = JobType.Fulltime, Salary = 100000, YearsExperienced = "1+", Description = @"A solution driven Fullstack Developer                                Proficient in NodeJS,
                                                    ElasticSearch,
                                                    MongoDB,
                                                    MySql or Postgres,
                                                    React
                                Experienced in building multi tenancy apps
                                Knowledge of CI / CD"
                }
            }
                );

            HomeController controller = new HomeController(mock.Object);
            string category = "Title";
            string search = "Senior Software Engineer";

            // Act
            var result = ((IEnumerable<Job>)controller.Index(null, null));

            // assert
           
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void About()
        {
            //    // Arrange
            //    HomeController controller = new HomeController();

            //    // Act
            //    ViewResult result = controller.About() as ViewResult;

            //    // Assert
            //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
    }
}
