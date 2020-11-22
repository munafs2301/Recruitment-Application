using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruitment.Domain.Entities;
using Recruitment.Domain.Enums;
using Recruitment.Web.Models;
using Recruitment.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Web.Services.Tests
{
    [TestClass()]
    public class ApplicantRepoTests
    {

        [TestMethod()]
        public void CreateTest()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            // Arrange
            Applicant applicant = new Applicant() { ApplicantId = 1, FirstName = "Muna", LastName = "Frank", Age = 22, EmailAddress = "marvelousfrank5@gmail.com", Gender = Gender.Female };

            //Act
            ApplicantRepo arepo = new ApplicantRepo();
            var result = arepo.Create(applicant).Result;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Arrange
            //Act
            //Assert
        }

        [TestMethod()]
        public void GetJobDetailsTest()
        {
            // Arrange
            //Act
            //Assert
        }

        [TestMethod()]
        public void EditTest()
        {
            // Arrange
            //Act
            //Assert
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            //Act
            //Assert
        }



    }
}