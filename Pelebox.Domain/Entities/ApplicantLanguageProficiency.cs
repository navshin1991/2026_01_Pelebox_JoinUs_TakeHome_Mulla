using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class ApplicantLanguageProficiency
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public int LanguageId { get; set; }

    public int ProficiencyLevelId { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;

    public virtual ProficiencyLevel ProficiencyLevel { get; set; } = null!;
}
