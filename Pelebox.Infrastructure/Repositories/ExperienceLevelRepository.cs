using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class ExperienceLevelRepository : IExperienceLevelRepository {

        private readonly ApplicationDbContext _context;
        public ExperienceLevelRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<ExperienceLevel>> GetAllAsync() {
            return await _context.ExperienceLevels.ToListAsync();
        }

        public async Task<ExperienceLevel?> GetByIdAsync(int id) {
            return await _context.ExperienceLevels.FindAsync(id);
        }
    }
}
