using System;
using System.Collections.Generic;

namespace goodbyecouchpotato.Models;

public partial class Player
{
    public string Account { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Playerstatus { get; set; }

    public int Coins { get; set; }
}
