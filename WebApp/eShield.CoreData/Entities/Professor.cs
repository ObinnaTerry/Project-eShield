using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class Professor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
