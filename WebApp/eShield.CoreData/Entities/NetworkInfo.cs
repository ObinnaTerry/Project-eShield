using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class NetworkInfo
{
    public int Id { get; set; }

    public string StudentId { get; set; } = null!;

    public int ExamId { get; set; }

    public string Ipaddress { get; set; } = null!;

    public string Macaddress { get; set; } = null!;
}
