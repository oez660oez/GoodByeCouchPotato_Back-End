using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class WeightRecord
{
    public int CId { get; set; }

    public DateTime WRecordDate { get; set; }

    public decimal? Weight { get; set; }
}
