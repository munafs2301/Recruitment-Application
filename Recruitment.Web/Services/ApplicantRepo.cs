using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Recruitment.Web.Services
{
    public class ApplicantRepo: IApplicantRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Applicant> Applicants { get { return db.Applicants; } }

        public async Task<Applicant> Details(int? id)
        {
            Applicant applicant = await db.Applicants.FindAsync(id);
            return applicant;

        }

        public async Task<string> Create(int? jobId, Applicant applicant)
        {
            Job selectedJob = db.Jobs.Where(m => m.JobId == jobId).FirstOrDefault();
            applicant.JobId = selectedJob.JobId;
            applicant.JobTitle = selectedJob.Title;
            db.Applicants.Add(applicant);
            await db.SaveChangesAsync();
            return "Application Submitted";
        }

        public void Edit(Applicant applicant)
        {
            Applicant newEntry = db.Applicants.Find(applicant.ApplicantId);
            if (newEntry != null)
            {
                newEntry.FirstName = applicant.FirstName;
                newEntry.LastName = applicant.LastName;
                newEntry.EmailAddress = applicant.EmailAddress;
                newEntry.Gender = applicant.Gender;
                newEntry.Age = applicant.Age;
                newEntry.Address = applicant.Address;
                newEntry.PhoneNumber = applicant.PhoneNumber;
                //newEntry.Image = applicant.Image;
                //newEntry.ImageMimeType = applicant.ImageMimeType;

                db.SaveChanges();
            }
        }
        
        public async Task<Applicant> Delete(int id)
        {
            Applicant applicant = await db.Applicants.FindAsync(id);
            db.Applicants.Remove(applicant);
            await db.SaveChangesAsync();
            return applicant;
        }
        
        

    }
}
