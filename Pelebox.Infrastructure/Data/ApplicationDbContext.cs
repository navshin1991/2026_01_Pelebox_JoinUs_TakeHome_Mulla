using Microsoft.EntityFrameworkCore;
using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Pelebox.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public virtual DbSet<AgeCategory> AgeCategories { get; set; }

        public virtual DbSet<ApplicantLanguageProficiency> ApplicantLanguageProficiencies { get; set; }

        public virtual DbSet<Pelebox.Domain.Entities.Application> Applications { get; set; }

        public virtual DbSet<DrivingExperienceLevel> DrivingExperienceLevels { get; set; }

        public virtual DbSet<ExperienceLevel> ExperienceLevels { get; set; }

        public virtual DbSet<Gender> Genders { get; set; }

        public virtual DbSet<Job> Jobs { get; set; }

        public virtual DbSet<JobCategory> JobCategories { get; set; }

        public virtual DbSet<JobStatus> JobStatuses { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<NoticePeriod> NoticePeriods { get; set; }

        public virtual DbSet<Nqflevel> Nqflevels { get; set; }

        public virtual DbSet<ProficiencyLevel> ProficiencyLevels { get; set; }

        public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
