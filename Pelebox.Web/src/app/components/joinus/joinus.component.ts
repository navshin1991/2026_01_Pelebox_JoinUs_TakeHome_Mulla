import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


interface JobOpening {
  title: string;
  category: string;
  location: string;
  description: string;
  badgeClass: string;
  hoverBorder: string;
  btnColor: string;
}

@Component({
  selector: 'app-joinus',
  templateUrl: './joinus.component.html',
  styleUrls: ['./joinus.component.scss']
})
export class JoinusComponent implements OnInit {

  applyForm!: FormGroup;
  showForm = false; // Toggle to show form inside detail view
  openings: any[] = [];
  selectedJob: any = null; // Variable to hold the currently selected job for the detail view
  isApplying = false;
  genders = [
    { id: 1, name: 'Male' },
    { id: 2, name: 'Female' },
    { id: 3, name: 'Prefer not to say' }
  ];
  nqfLevels = [
    { id: 5, name: 'NQF Level 5 (Higher Certificate)' },
    { id: 6, name: 'NQF Level 6 (Diploma)' },
    { id: 7, name: 'NQF Level 7 (Bachelor\'s Degree)' },
    { id: 8, name: 'NQF Level 8 (Honours / PG Diploma)' }
  ];


  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.initForm();
    // Replace this with: this.jobService.getOpenings().subscribe(...)

    this.openings = [
      {
        title: 'Financial Officer',
        category: 'Finance',
        location: 'Pretoria, SA',
        details: 'We are looking for a “Financial Officer” to execute, manage and improve our financial accounting management functions. In this role, you would be managing accounting records, continuously evaluating and managing risk, overseeing accounting operations, analysing financial data, monitoring expenditure, and forecasting revenue. You will also coordinate partnerships with external stakeholders on financial statements and auditing processes.\nThe ideal candidate is someone with strong analytical skills, good at resolving challenges, highly organized with a natural affinity for numbers. They would be joining the team to streamline our accounting functions and operations. They would provide financial analysis and reports. This position will generally oversee general accounting, accounts payable, accounts receivables management and statutory reporting, internal control, tax, and asset management.\nIf you are skilled and interested in working for a tech-enabled scale-up operating at the intersection of Access to Quality Healthcare, Digital Technology, and Social Impact, then Technovera might be your new home.',
        badgeClass: 'bg-blue-600/10 text-blue-800',
        hoverBorder: 'hover:border-blue-500',
        btnColor: 'text-blue-600'
      },
      {
        title: 'Learning & Impact Officer',
        category: 'Operation',
        location: 'Field Based',
        details: 'We are looking for a "Learning & Impact Officer" to co-develop, lead, and enhance our internal learning and reflection processes, ensuring continuous organisational improvement and maximised social impact delivery. This role is essential in fostering a vibrant culture of ongoing learning, enabling our teams to systematically analyze experiences, identify root causes of challenges, and proactively implement solutions. By doing so, this officer will play a critical role in helping us avoid repeating mistakes and consistently identifying new opportunities for strategic growth and operational excellence across all business activities, including operations, field services, and client engagement and management.\nThe Learning & Impact Officer will be responsible for the end-to-end management of our impact data, encompassing everything from meticulous data collection and insightful basic analysis to collaborating with external specialists for comprehensive impact measurement and rigorous evaluation. This individual will serve as a key custodian of our overall impact reporting and measurement framework, ensuring that our bi-annual reports are not only robust and data-driven but also insightful and compelling. These reports will effectively communicate our progress and achievements to both internal stakeholders, fostering organisational alignment, and external partners, funders, and clients, building trust and demonstrating tangible value.\nIf you are skilled and interested in working for a tech-enabled scale-up operating at the intersection of Access to Quality Healthcare, Digital Technology, and Social Impact, then Technovera might be your new home.',
        badgeClass: 'bg-emerald-600/10 text-emerald-800',
        hoverBorder: 'hover:border-emerald-500',
        btnColor: 'text-emerald-600'
      },
      {
        title: 'Operations Manager',
        category: 'Operations',
        location: 'Full-time',
        details: 'We are looking for a “Operations Manager” to Lead, Execute, Manage and Improve our day-to-day operational functions. In this role, you would be managing a team responsible for product assembly, overseeing daily activities, maintaining and growing our standard, improving performance, procuring material and resources while ensuring compliance. You will also coordinate supplier management activities and find ways to increase quality of our customer services and implement best practices across all levels. Ultimately, we require you to help us remain compliant, efficient and profitable during the course of our impact delivery.\nThe ideal candidate is someone with strong analytical skills, exceptional communications, attention to the detail, a continuous improvement mindset, good at resolving challenges, highly organized with a natural affinity for getting things done.They would be joining the team to lead, coordinate and improve our Pelebox product assembly, installations, field support services, and customers support functions.They would co- build operational policies and strategies that keep the organization functioning smoothly.This position will oversee short - and long - term activity planning and resource allocations to ensure that we deliver on time, maintain quality and remain cost effective.We are looking for someone who can run things, be the first one in and last one out.\nIf you are skilled and interested in working for a tech - enabled scale - up operating at the intersection of Access to Quality Healthcare, Digital Technology, and Social Impact, then Technovera might be your new home.\nDuties, Functions and Responsibilities:',
        badgeClass: 'bg-purple-600/10 text-purple-800',
        hoverBorder: 'hover:border-purple-500',
        btnColor: 'text-purple-600'
      },
    ];
  }

  viewJobDetails(job: any) {
    this.selectedJob = job;
    this.isApplying = false; // Reset form view when switching jobs
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  closeDetails() {
    this.selectedJob = null;
    this.isApplying = false;
    window.scrollTo({ top: 200, behavior: 'smooth' });
  }

  login() {
    window.location.href = 'https://www.pelebox.com/portal/login';
  }

  initForm() {
    this.applyForm = this.fb.group({
      FirstName: ['', [Validators.required, Validators.maxLength(100)]],
      Surname: ['', [Validators.required, Validators.maxLength(100)]],
      GenderId: [null, Validators.required],
      Email: ['', [Validators.required, Validators.email, Validators.maxLength(300)]],
      CellphoneNumber: ['', [Validators.required, Validators.pattern(/^0[0-9]{9}$/)]],
      LinkedInUrl: ['', Validators.maxLength(100)],
      IdORPassport: ['', [Validators.required, Validators.maxLength(100)]],
      AgeCategoryId: [null, Validators.required],
      WorkPermission: [true, Validators.required], // BIT maps to Boolean
      Qualification: ['', Validators.maxLength(150)],
      InstitutionOfQualification: ['', Validators.maxLength(500)],
      YearOfGraduation: [null],
      NQFLevelId: [null],
      OtherQualification: ['', Validators.maxLength(150)],
      HasDrivingLicense: [true, Validators.required],
      DriversLicenseCode: ['', Validators.maxLength(150)],
      DrivingExperienceLevelId: [null, Validators.required],
      JobStatusId: [null],
      ExperienceLevelId: [null],
      NoticePeriodId: [null],
      CurrentSalary: ['', [Validators.required, Validators.maxLength(100)]],
      ExpectedSalary: ['', [Validators.required, Validators.maxLength(100)]],
      EarliestStartDate: ['', Validators.required],
      PreferredStartDate: ['', Validators.required],
      WorkCommuteEstimationHours: ['', [Validators.required, Validators.maxLength(100)]],
      WorkCommuteEstimationKM: ['', [Validators.required, Validators.maxLength(100)]],
      WillingToRelocate: [false, Validators.required],
      AbilityToTravel: [false, Validators.required],
      WhySuitableForRole: ['', [Validators.required, Validators.maxLength(500)]],
      CVFile: [null, Validators.required],
      CoverLetterFile: [null, Validators.required]
    });
  }

  // Helper to check if a field is invalid
  isInvalid(controlName: string): boolean {
    const control = this.applyForm.get(controlName);
    return !!(control && control.invalid && (control.dirty || control.touched));
  }

  submitApplication() {
    if (this.applyForm.valid) {
      console.log('SQL Payload ready for 2026:', this.applyForm.value);
      // Logic to send FormData to your API
    } else {
      this.applyForm.markAllAsTouched();
    }
  }

  onFileChange(event: any, fieldName: string) {
    if (event.target.files.length > 0) {
      this.applyForm.patchValue({ [fieldName]: event.target.files[0] });
    }
  }
}
