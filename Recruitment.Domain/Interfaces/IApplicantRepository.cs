using Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruitment.Domain.Interfaces
{
    public interface IApplicantRepository
    {
        Task Edit(Applicant applicant);
        IEnumerable<Applicant> Applicants { get; }       
        Task<bool> Create(Applicant applicant);
        Task Delete(int id);
        Task<Applicant> Details(int? id);
        Task<Applicant> GetJobDetails(int? id);
    }
}
