using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IExperienceLevelRepository {
        Task<IEnumerable<ExperienceLevel>> GetAllAsync();
       Task<ExperienceLevel?> GetByIdAsync(int id);
    }
}
