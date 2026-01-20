using Pelebox.Application.Models;
using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IApplicationRepository {
        Task<IEnumerable<Pelebox.Domain.Entities.Application>> GetAllAsync();
        Task<Pelebox.Domain.Entities.Application?> GetByIdAsync(int id);
        Task<int> Add(ApplicationSubmitModel model, int createdBy);

    }
}
