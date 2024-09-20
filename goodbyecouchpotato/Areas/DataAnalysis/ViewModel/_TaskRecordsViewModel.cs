namespace goodbyecouchpotato.Areas.DataAnalysis.ViewModel
{
    public class _TaskRecordsViewModel
    {
        public int? CId { get; set; }

        public DateOnly? TrecordDate { get; set; }
        public DateOnly starttime { get; set; }
        public DateOnly endtime { get; set; }

        public string? T1name { get; set; }

        public bool? T1completed { get; set; }

        public string? T2name { get; set; }

        public bool? T2completed { get; set; }

        public string? T3name { get; set; }

        public bool? T3completed { get; set; }
    }
}
