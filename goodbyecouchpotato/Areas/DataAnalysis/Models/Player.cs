using System;
using System.Collections.Generic;

namespace goodbyecouchpotato.Models
{
    public partial class Player
    {
        public string account { get; set; } = null!;
        public string email { get; set; } = null!;
        public string? password { get; set; }
        public string? playerstatus { get; set; }
        public string? coin { get; set; }
    }
}
