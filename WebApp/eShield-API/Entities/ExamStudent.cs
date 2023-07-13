using System;
using System.Collections.Generic;

namespace eShield_API.Entities;

public partial class ExamStudent
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ExamId { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
