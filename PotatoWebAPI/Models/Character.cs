using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

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

    public int? StandardWater { get; set; }

    public int? StandardStep { get; set; }

    public int? Coins { get; set; }

    public int? TargetWater { get; set; }

    public int? TargetStep { get; set; }

    public int? GetEnvironment { get; set; }

    public int? GetExperience { get; set; }

    public int? GetCoins { get; set; }
}
