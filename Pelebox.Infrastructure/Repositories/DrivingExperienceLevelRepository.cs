using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class DrivingExperienceLevelRepository : IDrivingExperienceLevelRepository {

        private readonly ApplicationDbContext _context;
        public DrivingExperienceLevelRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<DrivingExperienceLevel>> GetAllAsync() {
            return await _context.DrivingExperienceLevels.ToListAsync();
        }

        public async Task<DrivingExperienceLevel?> GetByIdAsync(int id) {
            return await _context.DrivingExperienceLevels.FindAsync(id);
        }
    }
}
