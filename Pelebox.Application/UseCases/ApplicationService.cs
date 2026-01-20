using Pelebox.Application.Interfaces;
using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.UseCases {
    public class ApplicationService {

        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository) {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<Pelebox.Domain.Entities.Application>> GetJobs() => await _applicationRepository.GetAllAsync();

        public async Task<Pelebox.Domain.Entities.Application?> GetJobById(int id) => await _applicationRepository.GetByIdAsync(id);
    }
}
