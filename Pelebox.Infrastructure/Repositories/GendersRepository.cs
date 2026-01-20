using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class GendersRepository : IGendersRepository {

        private readonly ApplicationDbContext _context;
        public GendersRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetAllAsync() {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender?> GetByIdAsync(int id) {
            return await _context.Genders.FindAsync(id);
        }
    }
}
