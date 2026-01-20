using Pelebox.Application.Interfaces;
using Pelebox.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace Pelebox.Application.UseCases
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers() => await _userRepository.GetAllAsync();

        public async Task<User?> GetUserById(int id) => await _userRepository.GetByIdAsync(id);

        // Check for login
        public async Task<User?> UserValidate(string email, string password) => await _userRepository.GetByEmailPassword(email,password);
    }
}
