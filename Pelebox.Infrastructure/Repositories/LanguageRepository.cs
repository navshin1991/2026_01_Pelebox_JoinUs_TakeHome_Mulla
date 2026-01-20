using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class LanguageRepository : ILanguageRepository {

        private readonly ApplicationDbContext _context;
        public LanguageRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Language>> GetAllAsync() {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language?> GetByIdAsync(int id) {
            return await _context.Languages.FindAsync(id);
        }
    }
}
