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
       
        private readonly IJobRepository jrepo;
        private readonly IProcessApplication prepo;

        public AdminController(IJobRepository jrepo, IProcessApplication prepo)
        {
            this.jrepo = jrepo;
            this.prepo = prepo;
        }

        //DashBoard
        public ActionResult DashBoard()
        {
            return View();
        }

        #region Jobs Section
        public ActionResult Jobs()
        {
            return View(jrepo.Jobs);
        }

        // GET: Admin
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
                await jrepo.Create(job);
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
                await jrepo.Edit(job);
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
        #endregion

        #region Applications section
        public ActionResult Applications()
        {
            
            return View(prepo.Applications);
        }
        
        public ActionResult ApplicationDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Applicant applicant =  prepo.Details(id);
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
            await prepo.Accept(id);
            return RedirectToAction("Applications");
        }
        #endregion

        #region Helpers
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        #endregion
    }
}
