using Recruitment.Domain.Entities;
using Recruitment.Domain.Interfaces;
using Recruitment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Web.Services
{
    public class JobRepo: IJobRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Job> Jobs { get { return db.Jobs; } }
    }
}