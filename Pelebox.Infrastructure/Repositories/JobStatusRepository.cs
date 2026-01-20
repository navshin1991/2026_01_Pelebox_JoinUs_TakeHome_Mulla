using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class JobStatusRepository : IJobStatusRepository {

        private readonly ApplicationDbContext _context;
        public JobStatusRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<JobStatus>> GetAllAsync() {
            return await _context.JobStatuses.ToListAsync();
        }

        public async Task<JobStatus?> GetByIdAsync(int id) {
            return await _context.JobStatuses.FindAsync(id);
        }
    }
}
