namespace PotatoWebAPI.DTO
{
    public class WeeklyTaskDTO
    {
        public int CId { get; set; }
        public int countsport { get; set; }
        public int countclean { get; set; }

        public bool todaysport { get; set; }
        public bool todayclean { get; set; }

    }

    public class updateWeeklyTaskDTO
    {
        public int countsport { get; set; }
        public int countclean { get; set; }

        public bool todaysport { get; set; }
        public bool todayclean { get; set; }

        public string returnword { get; set; }

    }
}