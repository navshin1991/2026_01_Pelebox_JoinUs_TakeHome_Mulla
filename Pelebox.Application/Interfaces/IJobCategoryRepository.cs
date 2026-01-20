using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IJobCategoryRepository {
        Task<IEnumerable<JobCategory>> GetAllAsync();
        Task<JobCategory?> GetByIdAsync(int id);
    }
}
