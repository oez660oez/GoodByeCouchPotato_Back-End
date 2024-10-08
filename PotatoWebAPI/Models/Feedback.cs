using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class Feedback
{
    public int FeedbackNo { get; set; }

    public string Email { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Submitted { get; set; }

    public bool ProActive { get; set; }

    public DateTime? ProDate { get; set; }

    public string? ProContent { get; set; }
}
