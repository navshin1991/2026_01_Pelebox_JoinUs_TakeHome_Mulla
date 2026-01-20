using Pelebox.Application.Interfaces;
using Pelebox.Application.UseCases;
using Pelebox.Infrastructure.Repositories;
using System.Collections.Generic;

namespace Pelebox.API.Extension {
    public static class ServiceExtensions {
        public static void RegisterServices(this IServiceCollection service) {


            //****** Repository
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IAgeCategoryRepository, AgeCategoryRepository>();
            service.AddScoped<IApplicantLanguageProficiencyRepository, ApplicantLanguageProficiencyRepository>();
            service.AddScoped<IApplicationRepository, ApplicationRepository>();
            service.AddScoped<IDrivingExperienceLevelRepository, DrivingExperienceLevelRepository>();
            service.AddScoped<IExperienceLevelRepository, ExperienceLevelRepository>();
            service.AddScoped<IGendersRepository, GendersRepository>();
            service.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
            service.AddScoped<IJobStatusRepository, JobStatusRepository>();
            service.AddScoped<ILanguageRepository, LanguageRepository>();
            service.AddScoped<INoticePeriodRepository, NoticePeriodRepository>();
            service.AddScoped<INqflevelRepositoty, NqflevelRepositoty>();
            service.AddScoped<IProficiencyLevelRepository, ProficiencyLevelRepository>();
            service.AddScoped<IJobRepository, JobRepository>();

            //****** Services
            service.AddScoped<UserService>();
            service.AddScoped<JobService>();
            service.AddScoped<ApplicationService>();

        }
    }
}
