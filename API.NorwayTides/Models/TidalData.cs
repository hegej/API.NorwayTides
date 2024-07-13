namespace API.NorwayTides.Models
{
    public class TidalData
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int PrognosisLength { get; set; }
        public double Surge { get; set; }
        public double Tide { get; set; }
        public double Total { get; set; }
        public double Percentile0 { get; set; }
        public double Percentile25 { get; set; }
        public double Percentile50 { get; set; }
        public double Percentile75 { get; set; }
        public double Percentile100 { get; set; }
    }
}
