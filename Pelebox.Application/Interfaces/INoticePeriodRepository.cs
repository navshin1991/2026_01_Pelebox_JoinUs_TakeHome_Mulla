using Pelebox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Interfaces {
    public interface INoticePeriodRepository {
        Task<IEnumerable<NoticePeriod>> GetAllAsync();
        Task<NoticePeriod?> GetByIdAsync(int id);
    }
}
