using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class JobCategory
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
