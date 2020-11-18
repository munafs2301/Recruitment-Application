using Moq;
using Ninject;
using Recruitment.Domain.Entities;
using Recruitment.Domain.Enums;
using Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web.Services
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here
            Mock<IJobRepository> mock = new Mock<IJobRepository>();
            mock.Setup(m => m.Jobs).Returns(new List<Job>
            {
                new Job {JobId = 1, Title = "Graphics Designer", Company = "Bezao", Description = "Bla bLa BLa", Level = Level.Entry, Location = "Lagos", Salary = 50000, Type = JobType.Fulltime, YearsExperienced = "2+ years" },
                new Job {JobId = 2, Title = "Editor", Company = "Google", Description = "Bla bLa BLa", Level = Level.Entry, Location = "Lagos", Salary = 50000, Type = JobType.Fulltime, YearsExperienced = "2+ years" },
                new Job {JobId = 3, Title = "Graphics Designer", Company = "Bezao", Description = "Bla bLa BLa", Level = Level.Entry, Location = "Lagos", Salary = 50000, Type = JobType.Fulltime, YearsExperienced = "2+ years" },
                new Job {JobId = 4, Title = "Graphics Designer", Company = "Bezao", Description = "Bla bLa BLa", Level = Level.Entry, Location = "Lagos", Salary = 50000, Type = JobType.Fulltime, YearsExperienced = "2+ years" },
                new Job {JobId = 5, Title = "Graphics Designer", Company = "Google", Description = "Bla bLa BLa", Level = Level.Entry, Location = "Lagos", Salary = 50000, Type = JobType.Fulltime, YearsExperienced = "2+ years" },
                new Job {JobId = 6, Title = "Graphics Designer", Company = "Bezao", Description = "Bla bLa BLa", Level = Level.Entry, Location = "Lagos", Salary = 50000, Type = JobType.Fulltime, YearsExperienced = "2+ years" },
                new Job {JobId = 7, Title = "Graphics Designer", Company = "Bezao", Description = "Bla bLa BLa", Level = Level.Entry, Location = "Lagos", Salary = 50000, Type = JobType.Fulltime, YearsExperienced = "2+ years" }
            }
                );

            kernel.Bind<IJobRepository>().To<JobRepo>();
            kernel.Bind<IApplicantRepository>().To<ApplicantRepo>();
            kernel.Bind<IProcessApplication>().To<ProcessApplication>();
        }
    }
}