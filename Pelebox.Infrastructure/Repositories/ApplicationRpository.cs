using Microsoft.EntityFrameworkCore;
using Pelebox.Application.Models;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class ApplicationRepository : IApplicationRepository {

        private readonly ApplicationDbContext _context;
        public ApplicationRepository(ApplicationDbContext context) {
            _context = context;
        }

        public Task<int> Add(ApplicationSubmitModel model, int createdBy) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pelebox.Domain.Entities.Application>> GetAllAsync() {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Pelebox.Domain.Entities.Application> GetByIdAsync(int id) {
            return await _context.Applications.FindAsync(id);
        }
    }
}
