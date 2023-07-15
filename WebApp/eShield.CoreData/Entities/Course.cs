using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public int ProfessorId { get; set; }
}
