namespace PotatoWebAPI.DTO
{
    public class PreviousCharactersDTO
    {
        public int CId { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public string? LivingStatus { get; set; }

        public int? Coins { get; set; }

        public int? Head { get; set; }

        public int? Upper { get; set; }

        public int? Lower { get; set; }

        public string? MoveInDate { get; set; }

        public string? MoveOutDate { get; set; }
    }
}
