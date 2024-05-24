using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public string Description { get; set; } = null!;

    public bool HasCar { get; set; }

    public Guid OrderStatusId { get; set; }

    public DateOnly BookDateFrom { get; set; }

    public TimeOnly BookTimeFrom { get; set; }

    public DateOnly BookDateTo { get; set; }

    public TimeOnly BookTimeTo { get; set; }

    public Guid CostId { get; set; }

    public Guid RoomId { get; set; }

    public Guid DiscountId { get; set; }

    public Guid GuestId { get; set; }

    public Guid TariffId { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Cost Cost { get; set; } = null!;

    public virtual Discount Discount { get; set; } = null!;

    public virtual Guest Guest { get; set; } = null!;

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;
}
