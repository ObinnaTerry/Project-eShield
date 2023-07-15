using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ExamStudent> ExamStudents { get; set; } = new List<ExamStudent>();

    public virtual ICollection<NetworkInfo> NetworkInfos { get; set; } = new List<NetworkInfo>();

    public virtual ICollection<VisitedSite> VisitedSites { get; set; } = new List<VisitedSite>();
}
