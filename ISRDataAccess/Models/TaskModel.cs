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
        public decimal? PercentUsed { get; set; }
        public decimal? EstToComplHours { get; set; }
        public decimal? PercentComplete { get; set; }
        public decimal? DifferencePercent { get; set; }
        public decimal? ForecastHours { get; set; }
        public decimal? VarianceHours { get; set; }
        public decimal? VariancePercent { get; set; }


    }
}
