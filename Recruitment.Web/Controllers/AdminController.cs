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
using Recruitment.Web.Models;
using Recruitment.Web.Services;

namespace Recruitment.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
            Job job = await db.Jobs.FindAsync(id);
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
                db.Jobs.Add(job);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
            Job job = await db.Jobs.FindAsync(id);
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
                return RedirectToAction("Index");
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
            Job job = await db.Jobs.FindAsync(id);
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
            Job job = await db.Jobs.FindAsync(id);
            db.Jobs.Remove(job);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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


        [HttpPost]
        public async Task<ActionResult> Reject(int? id)
        {
            var application =  db.Applicants.Find(id);
            string messageSubject = "RECRUIT: Job Update";
            string messageBody = $"Hello Applicant,\n\nYou application did not meet up to our requirements. But not to worry, we will inform you of the next job opening that suits your application.\n\nRegards,\nMarvelous(HRM)";
            //string messageBody = $"Hello {application.FirstName},\nYou application for {application.JobTitle} was did not meet up to our requirements. But not to worry, we will inform you of the next job opening that suits your application.\nRegards,\nMarvelous(HRM)";
            Email.SendEmail("marvelousfrank5@gmail.com", messageSubject,  messageBody);
            //await Email.SendMail(application.EmailAddress,  messageBody,messageSubject);
            db.Applicants.Remove(application);
            await db.SaveChangesAsync();
            return RedirectToAction("Applications");
        }
        
        [HttpPost]
        public async Task<ActionResult> Accept(int? id)
        {
            var application = await db.Applicants.FindAsync(id);
            string messageSubject = "RECRUIT: Job Update";
            string messageBody = $"Congratulations {application.FirstName},\nYou application for {application.JobTitle} was accepted. Please report to the headquarters for your interview on Monday.\nRegards,\nMarvelous(HRM)";
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
