using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class Player
{
    public string Account { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Playerstatus { get; set; }

    public string Token { get; set; } = null!;

}
