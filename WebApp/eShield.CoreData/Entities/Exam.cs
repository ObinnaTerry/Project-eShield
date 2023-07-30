using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class Exam
{
    public int Id { get; set; }

    public int CreatedBy { get; set; }

    public int CourseId { get; set; }

    public DateTime ExamDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Professor CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<ExamStudent> ExamStudents { get; set; } = new List<ExamStudent>();

    public virtual ICollection<NetworkInfo> NetworkInfos { get; set; } = new List<NetworkInfo>();

    public virtual ICollection<VisitedSite> VisitedSites { get; set; } = new List<VisitedSite>();
}
