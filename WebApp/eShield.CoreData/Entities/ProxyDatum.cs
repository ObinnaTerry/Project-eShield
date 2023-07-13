using System;
using System.Collections.Generic;

namespace eShield.CoreData.Entities;

public partial class ProxyDatum
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public DateTime CreateTime { get; set; }
}
