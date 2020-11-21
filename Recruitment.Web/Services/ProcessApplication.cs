using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
using System.Threading.Tasks;


namespace Recruitment.Web.Services
{
    public class ProcessApplication: IProcessApplication
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Applicant> Applications { get { return db.Applicants; } }

        public Applicant Details(int? id)
        {
            var applicant = db.Applicants.Where(m => m.ApplicantId == id).FirstOrDefault();                 
            return applicant;
        }

        public async Task Reject(int id)
        {
            var applicant =  db.Applicants.Where(m => m.ApplicantId == id).FirstOrDefault();
            applicant.ApplicationStatus = 2;
            string messageSubject = "RECRUIT: Job Update";
            string messageBody = $"Hello {applicant.FirstName},\n\nYour application for {applicant.JobTitle} was did not meet up to our requirements. But not to worry, we will inform you of the next job opening that suits your application.\n\nRegards,\nMarvelous(HRM)";
            Email.SendEmail(applicant.EmailAddress,  messageSubject,messageBody);
            db.Applicants.Remove(applicant);
            await db.SaveChangesAsync();
        }       

        public async Task Accept(int? id)
        {
            var applicant = db.Applicants.Where(m => m.ApplicantId == id).FirstOrDefault();
            applicant.ApplicationStatus = 1;
            string messageSubject = "RECRUIT: Job Update";
            string messageBody = $"Congratulations {applicant.FirstName},\n\nYour application for {applicant.JobTitle} was accepted. Please report to the headquarters for your interview on Monday.\nNOTE: Come with your emails an evidence.\n\nRegards,\nMarvelous(HRM)";
            Email.SendEmail(applicant.EmailAddress, messageSubject, messageBody);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var applicant = db.Applicants.Where(m => m.ApplicantId == id).FirstOrDefault();
            db.Applicants.Remove(applicant);
            await db.SaveChangesAsync();
        }
    }
}