namespace PotatoWebAPI.DTO
{
    public class SearchdayDTO
    {
        public int CId { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }
    }

    public class SleepRecordDTO
    {
        public DateOnly HrecordDate { get; set; }
        public DateTime? Sleep { get; set; }
    }

    public class WaterRecordDTO
    {
        public DateOnly HrecordDate { get; set; }
        public int? water { get; set; }
    }

    public class StepRecordDTO
    {
        public DateOnly HrecordDate { get; set; }
        public int? step { get; set; }
    }

    public class MoodRecordDTO
    {
        public DateOnly HrecordDate { get; set; }
        public string? mood { get; set; }
    }

    public class weightRecordDTO
    {
        public DateOnly HrecordDate { get; set; }
        public decimal? weight { get; set; }
    }

    public class eatRecordDTO
    {
        public DateOnly HrecordDate { get; set; }
        public int? good { get; set; }
        public int? bad { get; set; }
    }
    public class weeklyRecordDTO
    {
        public DateOnly HrecordDate { get; set; }
        public bool? sport { get; set; }
        public bool? cleaning { get; set; }
    }
}
