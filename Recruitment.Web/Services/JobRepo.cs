using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Recruitment.Web.Services
{
    public class JobRepo: IJobRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Job> Jobs { get { return db.Jobs; } }

       
        public async Task<Job> Details(int? id)
        {
            Job job = await db.Jobs.FindAsync(id);
            return job;

        }
        
        public async Task Create(Job job)
        {
            db.Jobs.Add(job);
            await db.SaveChangesAsync();
        }

        public async Task Edit(Job job)
        {           
            db.Entry(job).State = EntityState.Modified;
            await db.SaveChangesAsync();          
        }

        public async Task Delete(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            db.Jobs.Remove(job);
            await db.SaveChangesAsync();
        }
    }

   
}