using System;
using System.Collections.Generic;

namespace eShield_API.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ExamStudent> ExamStudents { get; set; } = new List<ExamStudent>();

    public virtual ICollection<VisitedSite> VisitedSites { get; set; } = new List<VisitedSite>();
}
