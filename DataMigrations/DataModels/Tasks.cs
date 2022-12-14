using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISRDataAccess.Models
{
    public class Tasks
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TaskId")]
        public int TaskId { get; set; }
        public int JobId { get; set; }
        public int TaskName { get; set; }
        public DateTime LastUpdate { get; set; }
        public decimal QuotedHours { get; set; }
        public decimal ActualHours { get; set; }
        public decimal PercentUsed { get; set; }
        public decimal EstToComplHours { get; set; }
        public decimal PercentComplete { get; set; }
        public decimal DifferencePercent { get; set; }
        public decimal ForecastHours { get; set; }
        public decimal VarianceHours { get; set; }
        public decimal VariancePercent { get; set; }
        public decimal Weighting { get; set; }


    }
}
