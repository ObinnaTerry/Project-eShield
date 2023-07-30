using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class FlaggedSite
{
    public int Id { get; set; }

    public string Website { get; set; } = null!;
}
