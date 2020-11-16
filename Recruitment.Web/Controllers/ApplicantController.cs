using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantRepository arepo;

        public ApplicantController(IApplicantRepository arepo)
        {
            this.arepo = arepo;
        }

        // GET: Applicant
        public ActionResult Index()
        {
            var model = arepo.Applicants;
            return View(model);
        }

        // GET: Applicant/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await arepo.Details(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicant/Create
        public ActionResult Create(int? jobId)
        {
          
            return View();
        }

        // POST: Applicant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? jobId, Applicant applicant, HttpPostedFileBase image = null)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //if (image != null)
                    //{
                    //    applicant.ImageMimeType = image.ContentType;
                    //    applicant.Image = new byte[image.ContentLength];
                    //    image.InputStream.Read(applicant.Image, 0, image.ContentLength);                       
                    //}
                    arepo.Create(jobId, applicant);
                    TempData["message"] = string.Format("Your application for {0} has been submitted. ", applicant.JobTitle);
                }
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View(applicant);
            }
        }

        // GET: Applicant/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await arepo.Details(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicant/Edit/5
        [HttpPost]
        public ActionResult Edit(Applicant applicant)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    arepo.Edit(applicant);
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View(applicant);
            }
        }

        // GET: Applicant/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await arepo.Details(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                arepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //public FileContentResult GetImage(int applicantId)
        //{
        //    Applicant applicantImage = arepo.Applicants.FirstOrDefault(p => p.ApplicantId == applicantId);
        //    if (applicantImage != null)
        //    {
        //        return File(applicantImage.Image, applicantImage.ImageMimeType);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
