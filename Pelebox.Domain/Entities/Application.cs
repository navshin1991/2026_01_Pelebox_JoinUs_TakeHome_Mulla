using System;
using System.Collections.Generic;

namespace Pelebox.Domain.Entities;

public partial class Application
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int GenderId { get; set; }

    public string Email { get; set; } = null!;

    public string CellphoneNumber { get; set; } = null!;

    public string? LinkedInUrl { get; set; }

    public string IdOrpassport { get; set; } = null!;

    public int AgeCategoryId { get; set; }

    public bool WorkPermission { get; set; }

    public string? Qualification { get; set; }

    public string? InstitutionOfQualification { get; set; }

    public int? YearOfGraduation { get; set; }

    public int? NqflevelId { get; set; }

    public string? OtherQualification { get; set; }

    public bool HasDrivingLicense { get; set; }

    public string? DriversLicenseCode { get; set; }

    public int DrivingExperienceLevelId { get; set; }

    public int? JobStatusId { get; set; }

    public int? ExperienceLevelId { get; set; }

    public int? NoticePeriodId { get; set; }

    public string CurrentSalary { get; set; } = null!;

    public string ExpectedSalary { get; set; } = null!;

    public DateOnly EarliestStartDate { get; set; }

    public DateOnly PreferredStartDate { get; set; }

    public string WorkCommuteEstimationHours { get; set; } = null!;

    public string WorkCommuteEstimationKm { get; set; } = null!;

    public bool WillingToRelocate { get; set; }

    public bool AbilityToTravel { get; set; }

    public string WhySuitableForRole { get; set; } = null!;

    public string CvfilePath { get; set; } = null!;

    public string CoverLetterFilePath { get; set; } = null!;

    public DateTime AppliedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual AgeCategory AgeCategory { get; set; } = null!;

    public virtual ICollection<ApplicantLanguageProficiency> ApplicantLanguageProficiencies { get; set; } = new List<ApplicantLanguageProficiency>();

    public virtual DrivingExperienceLevel DrivingExperienceLevel { get; set; } = null!;

    public virtual ExperienceLevel? ExperienceLevel { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;

    public virtual JobStatus? JobStatus { get; set; }

    public virtual NoticePeriod? NoticePeriod { get; set; }

    public virtual Nqflevel? Nqflevel { get; set; }
}
