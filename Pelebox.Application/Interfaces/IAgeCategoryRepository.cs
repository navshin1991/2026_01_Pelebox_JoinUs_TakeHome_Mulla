using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IAgeCategoryRepository {
        Task<IEnumerable<AgeCategory>> GetAllAsync();
        Task<AgeCategory?> GetByIdAsync(int id);
    }
}
