using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class Job
{
    public int Id { get; set; }

    public int JobCategoryId { get; set; }

    public string Title { get; set; } = null!;

    public int NumberOfVacancies { get; set; }

    public string? Description { get; set; }

    public string? FilePath { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual JobCategory JobCategory { get; set; } = null!;
}
