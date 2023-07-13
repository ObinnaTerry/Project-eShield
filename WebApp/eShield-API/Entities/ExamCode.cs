using System;
using System.Collections.Generic;

namespace eShield_API.Entities;

public partial class ExamCode
{
    public int Id { get; set; }

    public int ExamId { get; set; }

    public int StudentId { get; set; }

    public string Code { get; set; } = null!;
}
