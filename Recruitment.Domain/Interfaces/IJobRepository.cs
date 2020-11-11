using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Domain.Interfaces
{
    public interface IJobRepository
    {
        IEnumerable<Job> Jobs { get; }
    }
}
