using Recruitment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Domain.Entities
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Int64 PhoneNumber { get; set; }
        public Byte[] PassportPhoto { get; set; }
        public Byte CV { get; set; }

    }
}
