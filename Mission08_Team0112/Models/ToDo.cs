using System;
using System.Collections.Generic;

namespace Mission08_Team0112.Models;

public partial class ToDo
{
    public int TaskId { get; set; }
    
    public string TaskName { get; set; }

    public string? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int CategoryId { get; set; }

    public bool Completed { get; set; }

    public virtual Category Category { get; set; } = null!;
}
