using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class Book
{
    public Guid BookId { get; set; }

    public Guid OrderId { get; set; }

    public Guid BookStatusTypeId { get; set; }

    public virtual BookStatusType BookStatusType { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
