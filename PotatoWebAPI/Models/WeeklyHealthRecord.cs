using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class WeeklyHealthRecord
{
    public int CId { get; set; }

    public DateOnly WrecordDate { get; set; }

    public bool Exercise { get; set; }

    public bool Cleaning { get; set; }
}
