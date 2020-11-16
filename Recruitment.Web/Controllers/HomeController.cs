using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
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
                    var senderEmail = new MailAddress("marvelousfrank5@gmail.com", "Marvelous");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "m4crystfs1998";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();

         
        }

        public ActionResult AllJobs()
        {
            var model = repo.Jobs;
            return View(model);
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}