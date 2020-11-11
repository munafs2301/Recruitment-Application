using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobRepository repo;

        public HomeController(IJobRepository repo)
        {
            this.repo = repo;
        }
        public ActionResult Index(string categories, string search)
        {
            var category = categories;
            IEnumerable<Job> model = repo.Jobs.Take(3);
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}