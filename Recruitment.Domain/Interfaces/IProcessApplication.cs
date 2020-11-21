using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Domain.Interfaces
{
    public interface IProcessApplication
    {
        IEnumerable<Applicant> Applications { get; }
        Applicant Details(int? id);
        Task Reject(int id);
        Task Accept(int? id);
        Task Delete(int id);

    }
}
