using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IProficiencyLevelRepository {
        Task<IEnumerable<ProficiencyLevel>> GetAllAsync();
        Task<ProficiencyLevel?> GetByIdAsync(int id);
    }
}
