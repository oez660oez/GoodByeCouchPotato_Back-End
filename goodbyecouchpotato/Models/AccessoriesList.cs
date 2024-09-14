using System;
using System.Collections.Generic;

namespace goodbyecouchpotato.Models;

public partial class AccessoriesList
{
    public int PCode { get; set; }

    public string PClass { get; set; } = null!;

    public string PName { get; set; } = null!;

    public int? PPrice { get; set; }

    public int? PLevel { get; set; }

    public string? PImageShop { get; set; }

    public string? PImageAll { get; set; }

    public bool PActive { get; set; }

    public string PReviewStatus { get; set; } = null!;
}
