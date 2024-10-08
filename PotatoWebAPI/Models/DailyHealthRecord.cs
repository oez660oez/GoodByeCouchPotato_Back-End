using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class DailyHealthRecord
{
    public int CId { get; set; }

    public DateOnly HrecordDate { get; set; }

    public int? Water { get; set; }

    public int? Steps { get; set; }

    public DateTime? Sleep { get; set; }

    public string? Mood { get; set; }

    public int? Vegetables { get; set; }

    public int? Snacks { get; set; }
}
