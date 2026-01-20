using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<ApplicantLanguageProficiency> ApplicantLanguageProficiencies { get; set; } = new List<ApplicantLanguageProficiency>();
}
