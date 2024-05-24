using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class OrderStatus
{
    public Guid OrderStatusId { get; set; }

    public string OrderStatusName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
