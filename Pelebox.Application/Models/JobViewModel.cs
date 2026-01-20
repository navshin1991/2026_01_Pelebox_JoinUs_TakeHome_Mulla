using Pelebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelebox.Application.Models {
    public class JobViewModel {
        public int Id { get; set; }

        public string JobCategory { get; set; }

        public string Title { get; set; } = null!;

        public int NumberOfVacancies { get; set; }

        public string? Description { get; set; }

        public string? FilePath { get; set; }
    }


}
