using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class NqflevelRepositoty : INqflevelRepositoty {

        private readonly ApplicationDbContext _context;
        public NqflevelRepositoty(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Nqflevel>> GetAllAsync() {
            return await _context.Nqflevels.ToListAsync();
        }

        public async Task<Nqflevel?> GetByIdAsync(int id) {
            return await _context.Nqflevels.FindAsync(id);
        }
    }
}
