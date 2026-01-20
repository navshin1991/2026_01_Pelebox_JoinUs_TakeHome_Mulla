using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public class ApplicantLanguageProficiencyRepository : IApplicantLanguageProficiencyRepository {

        private readonly ApplicationDbContext _context;
        public ApplicantLanguageProficiencyRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<ApplicantLanguageProficiency>> GetAllAsync() {
            return await _context.ApplicantLanguageProficiencies.ToListAsync();
        }

        public async Task<ApplicantLanguageProficiency?> GetByIdAsync(int id) {
            return await _context.ApplicantLanguageProficiencies.FindAsync(id);
        }
    }
}
