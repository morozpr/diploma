using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class RoomType
{
    public Guid RoomTypeId { get; set; }

    public string RoomTypeName { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
