using System;
using System.Collections.Generic;

namespace v001.Models;

public partial class BookStatusType
{
    public Guid BookStatusTypeId { get; set; }

    public string BookStatusTypeName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
