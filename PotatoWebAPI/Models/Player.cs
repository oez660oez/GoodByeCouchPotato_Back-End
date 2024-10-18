using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class Player
{
    public string? Account { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool Playerstatus { get; set; }

    public string? Token { get; set; }

}
