using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IJobStatusRepository {
        Task<IEnumerable<JobStatus>> GetAllAsync();
        Task<JobStatus?> GetByIdAsync(int id);
    }
}
