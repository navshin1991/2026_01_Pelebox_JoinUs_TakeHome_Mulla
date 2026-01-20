using Pelebox.Application.Interfaces;
using Pelebox.Application.Models;
using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.UseCases {
    public class JobService {
        private readonly IJobRepository _jobRepository;
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobService(IJobRepository jobRepository, IJobCategoryRepository jobCategoryRepository) {
            _jobRepository = jobRepository;
            _jobCategoryRepository = jobCategoryRepository;
        }

        public async Task<IEnumerable<JobViewModel>> GetJobs() => await _jobRepository.GetAllAsync();

        public async Task<IEnumerable<JobCategory>> get() => await _jobCategoryRepository.GetAllAsync();

        public async Task<Job?> GetJobById(int id) => await _jobRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Job>> GetJobsByCategoryId(int id) => await _jobRepository.GetJobsByCategoryIdAsync(id);

    }
}
