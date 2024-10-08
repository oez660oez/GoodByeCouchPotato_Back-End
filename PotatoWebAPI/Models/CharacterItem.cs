using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class CharacterItem
{
    public string Account { get; set; } = null!;

    public int PCode { get; set; }
}
