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
using System.IO;
using Recruitment.Web.Services;

namespace Recruitment.Web.Controllers
{
    [Authorize]
    public class ApplicantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applicants
        public async Task<ActionResult> Index()
        {
            return View(await db.Applicants.ToListAsync());
        }

        // GET: Applicants/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await db.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public async Task<ActionResult> Create(int? id, string title)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant application = new Applicant();
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }           
            application.JobId = job.JobId;
            application.JobTitle = title;
            ViewBag.message = title;
            return View(application);           
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Applicant application, byte[] image)
        {
            if (ModelState.IsValid)
            {
                //if (image != null)
                //{
                //    application.ImageContentType = image.ContentType;
                //    application.Image = new byte[image.InputStream.Length];
                //    image.InputStream.Read(application.Image, 0, image.ContentLength);
                //}
                //db.Applicants.Add(application);

                
                //using (BinaryReader br = new BinaryReader(image.InputStream))
                //{
                //    application.Image = br.ReadBytes(image.ContentLength);
                //}
                //application.ImageContentType = image.ContentType;
                db.Applicants.Add(application);

                await db.SaveChangesAsync();
                string messageSubject = $"Application Submission for {application.JobTitle}";
                string messageBody = $"Hello Admin,\n A new application submitted for {application.JobTitle}";
                Email.SendEmail("marvelousfrank5@gmail.com", messageSubject, messageBody);
                TempData["message"] = string.Format("Your application for {0} has been submitted. ", application.JobTitle);
                return RedirectToAction("Index", "Manage");
            }

            return View(application);
        }

        // GET: Applicants/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await db.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ApplicantId,FirstName,LastName,EmailAddress,Gender,Age,Address,PhoneNumber,JobId,JobTitle")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await db.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Applicant applicant = await db.Applicants.FindAsync(id);
            db.Applicants.Remove(applicant);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
//if (image != null && image.ContentLength > 0)
//{

//    using (var reader = new System.IO.BinaryReader(image.InputStream))
//    {
//        application.ImageContentType = image.ContentType;
//        application.Image = reader.ReadBytes(image.ContentLength);
//    }

//}