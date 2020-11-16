using Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruitment.Domain.Interfaces
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> Applicants { get; }

       
        Task<string> Create(int? jobId, Applicant applicant);
        Task<Applicant> Delete(int id);
        Task<Applicant> Details(int? id);
        void Edit(Applicant applicant);
    }
}
