namespace PotatoWebAPI.DTO
{
    public class DailytaskgetidDTO
    {
        public int CId { get; set; }
    }
    public class DailytaskDTO
    {
        public int CId { get; set; }
        public string T1name { get; set; }
        public bool T1completed { get; set; }
        public int T1Reward { get; set; }
        public string T2name { get; set; }
        public bool T2completed { get; set; }
        public int T2Reward { get; set; }
        public string T3name { get; set; }
        public bool T3completed { get; set; }
        public int T3Reward { get; set; }
    }
}
