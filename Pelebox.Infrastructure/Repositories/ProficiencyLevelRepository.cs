using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class ProficiencyLevelRepository : IProficiencyLevelRepository {

        private readonly ApplicationDbContext _context;
        public ProficiencyLevelRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<ProficiencyLevel>> GetAllAsync() {
            return await _context.ProficiencyLevels.ToListAsync();
        }

        public async Task<ProficiencyLevel?> GetByIdAsync(int id) {
            return await _context.ProficiencyLevels.FindAsync(id);
        }
    }
}
