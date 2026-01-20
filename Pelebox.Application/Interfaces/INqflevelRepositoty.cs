using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface INqflevelRepositoty {
        Task<IEnumerable<Nqflevel>> GetAllAsync();
        Task<Nqflevel> GetByIdAsync(int id);
    }
}
