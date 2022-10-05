using DataMigrations.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMigrations.DataModels
{
    public class Tasks
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        public string UUID { get; set; }

        [ForeignKey("job")]
        public int JobId { get; set; }
        public string TaskName { get; set; }
        public DateTime LastUpdate { get; set; }
        public decimal QuotedHours { get; set; }
        public decimal ActualHours { get; set; }
        public decimal PercentUsed { get; set; }
        public decimal EstToComplHours { get; set; }
        public decimal TotalForecastHours { get; set; }
        public Job job { get; set; }

    }
}
