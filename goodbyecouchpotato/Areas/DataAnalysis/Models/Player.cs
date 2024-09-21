using System;
using System.Collections.Generic;

namespace goodbyecouchpotato.Models
{
    public partial class Player
    {
        public int Level { get; set; }
        public decimal Weight { get; set; } // 使用 decimal，無需指定小數精度
        public decimal Height { get; set; } // 使用 decimal，無需指定小數精度
        public string? LivingStatus { get; set; }
    }
}
