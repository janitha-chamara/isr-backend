namespace ISRDataAccess.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public int JobId { get; set; }
        public string UUID { get; set; }
        public string? TaskName { get; set; }
        public DateTime? LastUpdate { get; set; }
        public decimal? QuotedHours { get; set; }
        public decimal? ActualHours { get; set; }
        public decimal? CurrentQuoteHoursUsed { get; set; }
        public decimal? EstToComplHours { get; set; }
        public decimal? TotalForecastHours { get; set; }
       


    }
}
