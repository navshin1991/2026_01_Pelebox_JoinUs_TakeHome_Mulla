using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class DrivingExperienceLevel
{
    public int Id { get; set; }

    public string Level { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
