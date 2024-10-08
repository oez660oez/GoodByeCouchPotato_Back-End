using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class Administrator
{
    public string AAccount { get; set; } = null!;

    public string APassword { get; set; } = null!;

    public bool MDailyTask { get; set; }

    public bool MProduct { get; set; }

    public bool MAdministrator { get; set; }
}
