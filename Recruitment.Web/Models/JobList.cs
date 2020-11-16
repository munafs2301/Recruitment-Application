using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Web.Models
{
    public class JobList
    {
        public IEnumerable<JobList> Jobs { get; set; }
        public Job  Job { get; set; }
    }
}