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

        public async Task<bool> Create(Applicant applicant)
        {          

            db.Applicants.Add(applicant);
            await db.SaveChangesAsync();
            string messageSubject = $"Application Submission for {applicant.JobTitle}";
            string messageBody = $"Hello Admin,\n\n A new application submitted for {applicant.JobTitle}";
            // Email notification is sent to the Admin's Email: marvelousfrank5@gmail.com
            Email.SendEmail("marvelousfrank5@gmail.com", messageSubject, messageBody);
            return true;
        }

        public async Task<Applicant> GetJobDetails(int? id)
        {
            Applicant applicant = new Applicant();
            Job job = await db.Jobs.FindAsync(id);
            applicant.JobId = job.JobId;
            applicant.JobTitle = job.Title;
            return applicant;
        }

        public async Task Edit(Applicant applicant)
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

                await db.SaveChangesAsync();

            }
        }

        public async Task Delete(int id)
                {
                    Applicant applicant = await db.Applicants.FindAsync(id);
                    db.Applicants.Remove(applicant);
                    await db.SaveChangesAsync();
                }

       
    }
}
