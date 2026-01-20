using Microsoft.EntityFrameworkCore;
using Pelebox.Application.Interfaces;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pelebox.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
 
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task AddAsync(User user) {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User?> GetByIdAsync(int id) {
            return await _context.Users.FindAsync(id);
        }
        public async Task<IEnumerable<User>> GetAllAsync() {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailPassword(string email,string password) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
