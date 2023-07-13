using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class VisitedSite
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ExamId { get; set; }

    public string Website { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
