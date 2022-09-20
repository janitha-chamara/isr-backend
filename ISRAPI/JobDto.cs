

using ISRDataAccess.Models;

namespace ISRAPI
{
    public class JobDto
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

    public static class JobDtoMapExtensions
    {
        public static JobModel ToJobModel(this JobDto jobDto)
        {
            var dst = new JobModel();
            dst.StatusID = jobDto.StatusID;
            return dst;
        }

        public static JobDto ToJobDto(this JobModel jobModel)
        {
            var dst = new JobDto();
            dst.StatusID = jobModel.StatusID;
            dst.AccountManagerID = jobModel.AccountManagerID;
            dst.LastUpdate = jobModel.LastUpdate;
            dst.DueDate = jobModel.DueDate;
            dst.JobCategory = jobModel.JobCategory;
            dst.StartDate = jobModel.StartDate;
            dst.WFMLastUpdate = jobModel.WFMLastUpdate;




            return dst;
        }

    }
}
