using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface IApplicantLanguageProficiencyRepository {
        Task<IEnumerable<ApplicantLanguageProficiency>> GetAllAsync();
        Task<ApplicantLanguageProficiency?> GetByIdAsync(int id);
    }
}
