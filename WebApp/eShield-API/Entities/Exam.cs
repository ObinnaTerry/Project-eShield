using System;
using System.Collections.Generic;

namespace eShield_API.Entities;

public partial class Exam
{
    public int Id { get; set; }

    public int CreatedBy { get; set; }

    public int CourseId { get; set; }

    public DateTime ExamDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public virtual ICollection<ExamStudent> ExamStudents { get; set; } = new List<ExamStudent>();

    public virtual ICollection<VisitedSite> VisitedSites { get; set; } = new List<VisitedSite>();
}
