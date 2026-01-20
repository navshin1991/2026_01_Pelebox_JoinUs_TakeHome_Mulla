using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IDrivingExperienceLevelRepository {
        Task<IEnumerable<DrivingExperienceLevel>> GetAllAsync();
        Task<DrivingExperienceLevel?> GetByIdAsync(int id);
    }
}
