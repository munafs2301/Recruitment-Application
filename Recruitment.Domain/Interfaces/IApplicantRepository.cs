using Recruitment.Domain.Entities;
using System.Collections.Generic;

namespace Recruitment.Domain.Interfaces
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> Applicants { get; }
    }
}
