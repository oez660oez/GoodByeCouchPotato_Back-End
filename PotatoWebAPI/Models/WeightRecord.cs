using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class WeightRecord
{
    public int CId { get; set; }

    public DateOnly WRecordDate { get; set; }

    public decimal? Weight { get; set; }
}
