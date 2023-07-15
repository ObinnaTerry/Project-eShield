using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class ExamCode
{
    public int Id { get; set; }

    public int ExamId { get; set; }

    public string Code { get; set; } = null!;
}
