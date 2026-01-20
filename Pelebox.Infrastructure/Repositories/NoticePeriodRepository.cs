using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class NoticePeriodRepository : INoticePeriodRepository {

        private readonly ApplicationDbContext _context;
        public NoticePeriodRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<NoticePeriod>> GetAllAsync() {
            return await _context.NoticePeriods.ToListAsync();
        }

        public async Task<NoticePeriod?> GetByIdAsync(int id) {
            return await _context.NoticePeriods.FindAsync(id);
        }
    }
}
