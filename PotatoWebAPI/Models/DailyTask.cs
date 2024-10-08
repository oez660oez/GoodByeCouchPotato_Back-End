using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class DailyTask
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public int Reward { get; set; }

    public bool TaskActive { get; set; }

    public string TReviewStatus { get; set; } = null!;
}
