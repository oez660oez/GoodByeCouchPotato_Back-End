namespace PotatoWebAPI.DTO
{
    public class DailyHealthRecordDTO
    {
        public int CId { get; set; }

        public DateOnly HrecordDate { get; set; }

        public int? Water { get; set; }

        public int? Steps { get; set; }

        public string? Sleep { get; set; }

        public string? Mood { get; set; }

        public int? Vegetables { get; set; }

        public int? Snacks { get; set; }

        public bool Exercise { get; set; }

        public bool Cleaning { get; set; }

    }
}
