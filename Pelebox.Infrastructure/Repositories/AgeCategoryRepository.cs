using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class AgeCategoryRepository : IAgeCategoryRepository {

        private readonly ApplicationDbContext _context;
        public AgeCategoryRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<AgeCategory>> GetAllAsync() {
            return await _context.AgeCategories.ToListAsync();
        }

        public async Task<AgeCategory?> GetByIdAsync(int id) {
            return await _context.AgeCategories.FindAsync(id);
        }
    }
}
