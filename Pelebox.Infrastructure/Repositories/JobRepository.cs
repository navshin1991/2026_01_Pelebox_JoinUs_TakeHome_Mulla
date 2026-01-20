using Microsoft.EntityFrameworkCore;
using Pelebox.Application.Models;
using Pelebox.Domain.Entities;
using Pelebox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Pelebox.Application.Interfaces {
    public class JobRepository : IJobRepository {

        private readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<JobViewModel>> GetAllAsync() {
            
             var query = from job in _context.Jobs
                         join jobCategory in _context.JobCategories on job.JobCategoryId equals jobCategory.Id
                         where jobCategory.Id == job.JobCategoryId
                         select new JobViewModel {
                             Id= job.Id,
                             Description= job.Description,
                             JobCategory = jobCategory.Description,
                             Title = job.Title,
                             FilePath = job.FilePath,
                             NumberOfVacancies = job.NumberOfVacancies
                         };

            return await query.ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(int id) {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task<IEnumerable<Job>> GetJobsByCategoryIdAsync(int id) {
            var query = from job in _context.Jobs
                        join jobCategory in _context.JobCategories on job.JobCategoryId equals jobCategory.Id
                        where jobCategory.Id == id
                        select job;

            return await query.ToListAsync();
        }
    }
}
