using System;

namespace goodbyecouchpotato.Models
{
    public partial class Player
    {
        public int Level { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string? LivingStatus { get; set; }
        public DateTime MoveInDate { get; set; } // 新增這一行
    }
}