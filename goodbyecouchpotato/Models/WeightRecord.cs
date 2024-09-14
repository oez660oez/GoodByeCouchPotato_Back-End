using System;
using System.Collections.Generic;

namespace goodbyecouchpotato.Models;

public partial class WeightRecord
{
    public int CId { get; set; }

    public DateTime WRecordDate { get; set; }

    public int Weight { get; set; }
}
