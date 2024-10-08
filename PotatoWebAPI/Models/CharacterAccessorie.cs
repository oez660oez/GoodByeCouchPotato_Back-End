using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class CharacterAccessorie
{
    public int CId { get; set; }

    public int? Head { get; set; }

    public int? Upper { get; set; }

    public int? Lower { get; set; }
}
