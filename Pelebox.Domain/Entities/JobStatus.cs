using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class JobStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
