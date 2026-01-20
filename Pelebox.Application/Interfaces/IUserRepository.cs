using Pelebox.Domain.Entities;
using System.Collections.Generic;

namespace Pelebox.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByEmailPassword(string email, string password);
    }
}