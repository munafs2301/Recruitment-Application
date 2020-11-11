using Recruitment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Web.Models
{
    public class Category
    {
        public Level Level { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public Type Type { get; set; }
    }
}