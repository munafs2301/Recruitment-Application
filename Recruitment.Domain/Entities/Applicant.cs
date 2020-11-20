using Recruitment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Recruitment.Domain.Entities
{
    public class Applicant
    {
        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "Please your First Name ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please your Last Name ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name= "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Choose a gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please input your age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter your home address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter your phone number")]
        [Display(Name = "Phone Number")]
        public Int64 PhoneNumber { get; set; }

        public int JobId { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        public int ApplicationStatus { get; set; }
        
        public string UserId { get; set; }

        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Upload Resume")]
        public string ResumePath { get; set; }


        //public byte[] Image { get; set; }

        //public string ImageContentType { get; set; }



    }
}
