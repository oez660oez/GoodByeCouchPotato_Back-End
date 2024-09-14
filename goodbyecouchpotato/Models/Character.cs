using System;
using System.Collections.Generic;

namespace goodbyecouchpotato.Models;

public partial class Character
{
    public int CId { get; set; }

    public string Account { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public int Experience { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public int? Environment { get; set; }

    public string? LivingStatus { get; set; }

    public DateTime? MoveInDate { get; set; }

    public DateTime? MoveOutDate { get; set; }
}
