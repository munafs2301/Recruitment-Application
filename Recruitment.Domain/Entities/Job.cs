using Recruitment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Domain.Entities
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Level Level { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public string Company { get; set; }
        public string YearsExperienced { get; set; }
        public JobType Type { get; set; }

        //public ICollection<Applicant> Applicants { get; set; }

    }
}
