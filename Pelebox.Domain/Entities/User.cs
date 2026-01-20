using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
