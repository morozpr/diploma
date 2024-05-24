using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class Guest
{
    public Guid GuestId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Sex { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
