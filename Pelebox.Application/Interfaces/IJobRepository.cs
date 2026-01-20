using Pelebox.Application.Models;
using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IJobRepository {
        Task<IEnumerable<JobViewModel>> GetAllAsync();

        Task<Job?> GetByIdAsync(int id);

        Task<IEnumerable<Job>> GetJobsByCategoryIdAsync(int id);
    }
}
