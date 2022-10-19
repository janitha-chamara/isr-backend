using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRDataAccess.Models
{
    public class JobModelData
    {
        public int Id { get; set; }
        public string? JobId { get; set; }
        public string UUID { get; set; }
        public string? JobName { get; set; }
        public string? ClientName { get; set; }
        public string? ProjectManger { get; set; }
        public string? SDM { get; set; }
        public string? ProjectStatus { get; set; }
        public decimal? QuotedHours { get; set; }
        public decimal? ActualHours { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? WFMLastUpdate { get; set; }
        public decimal? CurrentQuotedHoursUsed { get; set; }
        public decimal? EstToComplHours { get; set; }
        public decimal? TotalForeCastHours { get; set; }
        public decimal? CurrentthroughProject { get; set; }
        public decimal? ForecastQuotedHours { get; set; }
        public int? isAllTaskComplite { get; set; }

    }
}
