using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
using Recruitment.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobRepository repo;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public HomeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public HomeController(IJobRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index(string categories, string search)
        {
            var category = categories;
            IEnumerable<Job> model = repo.Jobs.OrderByDescending(m => m.JobId).Take(4);
            switch (category)
            {
                case "Title":
                    model = repo.Jobs.Where(m => m.Title.ToLower().Contains(search.ToLower()));
                    break;  
                case "Company":
                    model = repo.Jobs.Where(m => m.Company.ToLower().Contains(search.ToLower()));
                    break;  
                case "Location":
                    model = repo.Jobs.Where(m => m.Location.ToLower().Contains(search.ToLower()));
                    break;       
                default:                   
                    break;
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string receiver, string subject, string message)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    Email.SendEmail("munaproject20@gmail.com", "munaproject20@gmail.com", subject, message);
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Unable to send message. Some error Ocurred";
            }
            return View();

         
        }

        public ActionResult AllJobs(string categories, string search)
        {
            var category = categories;
            IEnumerable<Job> model = repo.Jobs.OrderByDescending(m => m.JobId);
            switch (category)
            {
                case "Title":
                    model = repo.Jobs.Where(m => m.Title.ToLower().Contains(search.ToLower()));
                    break;
                case "Company":
                    model = repo.Jobs.Where(m => m.Company.ToLower().Contains(search.ToLower()));
                    break;
                case "Location":
                    model = repo.Jobs.Where(m => m.Location.ToLower().Contains(search.ToLower()));
                    break;
                default:
                    
                    break;
            }
            return View(model);
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}