using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class Room
{
    public Guid RoomId { get; set; }

    public Guid RoomTypeId { get; set; }

    public string RoomName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual RoomType RoomType { get; set; } = null!;
}
