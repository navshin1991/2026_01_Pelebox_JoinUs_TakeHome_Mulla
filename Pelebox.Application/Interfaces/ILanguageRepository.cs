using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface ILanguageRepository {
        Task<IEnumerable<Language>> GetAllAsync();
        Task<Language?> GetByIdAsync(int id);
    }
}
