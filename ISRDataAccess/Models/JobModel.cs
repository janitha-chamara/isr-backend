using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRDataAccess.Models
{
    public class JobModel
    {
        public int JobId { get; set; }
        public string JobNo { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string StatusID { get; set; }
        public string JobCategory { get; set; }
        public int ClientID { get; set; }
        public int BusinessUnitID { get; set; }
        public int WFMId { get; set; }
        public string WFMLastUpdate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int ProjectMangerID { get; set; }
        public int AccountManagerID { get; set; }
        public decimal QuotedHours { get; set; }
        public decimal ActualHours { get; set; }
        public decimal PercentUsed { get; set; }
        public decimal EstToComplHours { get; set; }
        public decimal PercentComplete { get; set; }
        public decimal DifferencePercent { get; set; }
        public decimal ForecastHours { get; set; }
        public decimal VarianceHours { get; set; }
        public decimal VariancePercent { get; set; }

    }
}
