using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class Tariff
{
    public Guid TariffId { get; set; }

    public string TariffName { get; set; } = null!;

    public DateOnly DateSet { get; set; }

    public DateOnly? DateUnset { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
