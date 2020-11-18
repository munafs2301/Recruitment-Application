using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
using Recruitment.Web.Services;

namespace Recruitment.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IJobRepository jrepo;
        private readonly IProcessApplication prepo;
        private readonly IApplicantRepository arepo;

        public AdminController(IJobRepository jrepo, IProcessApplication prepo)
        {
            this.jrepo = jrepo;
            this.prepo = prepo;
            this.arepo = arepo;
        }

        // GET: Admin
        public ActionResult DashBoard()
        {
            return View();
        }

        // GET: Admin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await jrepo.Details(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "JobId,Title,Description,Level,Location,Salary,Company,YearsExperienced,Type")] Job job)
        {
            if (ModelState.IsValid)
            {
                jrepo.Create(job);
                return RedirectToAction("Jobs");
            }

            return View(job);
        }
        

        // GET: Admin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await jrepo.Details(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "JobId,Title,Description,Level,Location,Salary,Company,YearsExperienced,Type")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Jobs");
            }
            return View(job);
        }

        // GET: Admin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await jrepo.Details(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await jrepo.Delete(id);
            return RedirectToAction("Jobs");
        }

        public async Task<ActionResult> Applications()
        {
            var applications = await db.Applicants.ToListAsync();
            return View(applications);
        }

        public async Task<ActionResult> Jobs()
        {
            var jobs = await db.Jobs.ToListAsync();
            return View(jobs);
        }
        
        public async Task<ActionResult> ApplicationDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Applicant applicant = await prepo.Details(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }
               
        
        public async Task<ActionResult> Reject(int id)
        {
            await prepo.Reject(id);
            return RedirectToAction("Applications");
        }
        
        
        public async Task<ActionResult> Accept(int? id)
        {
            var application = await db.Applicants.FindAsync(id);
            string messageSubject = "RECRUIT: Job Update";
            string messageBody = $"Congratulations {application.FirstName},\n\nYou application for {application.JobTitle} was accepted. Please report to the headquarters for your interview on Monday.\n\nRegards,\nMarvelous(HRM)";
            Email.SendEmail(application.EmailAddress, messageSubject,  messageBody);
            db.Applicants.Remove(application);
            await db.SaveChangesAsync();
            return RedirectToAction("Applications");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
