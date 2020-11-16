using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Web.Models
{
    public class ApplicationViewModel
    {
        public Applicant Applicant { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }
    }
}