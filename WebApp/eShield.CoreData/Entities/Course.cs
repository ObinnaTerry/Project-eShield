using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public int ProfessorId { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
