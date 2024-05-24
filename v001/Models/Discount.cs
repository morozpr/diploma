using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class Discount
{
    public Guid DiscountId { get; set; }

    public int DiscountValue { get; set; }

    public DateOnly DateSet { get; set; }

    public DateOnly? DateUnset { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
