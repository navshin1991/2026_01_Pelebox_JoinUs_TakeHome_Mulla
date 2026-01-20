using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IGendersRepository {
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<Gender?> GetByIdAsync(int id);
    }
}
