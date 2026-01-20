using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class JobCategoryRepository : IJobCategoryRepository {

        private readonly ApplicationDbContext _context;
        public JobCategoryRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<JobCategory>> GetAllAsync() {
            return await _context.JobCategories.ToListAsync();
        }

        public async Task<JobCategory?> GetByIdAsync(int id) {
            return await _context.JobCategories.FindAsync(id);
        }
    }
}
