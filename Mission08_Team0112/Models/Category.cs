using System;
using System.Collections.Generic;

namespace Mission08_Team0112.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();
}
