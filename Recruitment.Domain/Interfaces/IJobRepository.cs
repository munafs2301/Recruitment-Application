﻿using Recruitment.Domain.Entities;
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
        Task<Job> Details(int? id);
        Task Create(Job job);
        Task Edit(Job job);
        Task Delete(int id);
    }
}
