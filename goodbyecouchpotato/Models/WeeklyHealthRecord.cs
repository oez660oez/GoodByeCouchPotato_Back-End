using System;
using System.Collections.Generic;

namespace goodbyecouchpotato.Models;

public partial class WeeklyHealthRecord
{
    public int CId { get; set; }

    public DateTime WrecordDate { get; set; }

    public bool Exercise { get; set; }

    public bool Cleaning { get; set; }
}
