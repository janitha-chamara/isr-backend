

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
        public bool ManageVisaISR { get; set; }
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
            var job = new JobModel();

            job.JobId = jobDto.JobId;
            job.JobNo = jobDto.JobNo;
            job.JobName = jobDto.JobName;
            job.Description = jobDto.Description;
            job.StartDate = jobDto.StartDate;
            job.DueDate = jobDto.DueDate;
            job.StatusID = jobDto.StatusID;
            job.JobCategory = jobDto.JobCategory;
            job.ManageVisaISR = jobDto.ManageVisaISR;
            job.ClientID = jobDto.ClientID;
            job.BusinessUnitID = jobDto.BusinessUnitID;
            job.WFMId = jobDto.WFMId;
            job.WFMLastUpdate = jobDto.WFMLastUpdate;
            job.LastUpdate = jobDto.LastUpdate;
            job.ProjectMangerID = jobDto.ProjectMangerID;
            job.AccountManagerID = jobDto.AccountManagerID;
            job.QuotedHours = jobDto.QuotedHours;
            job.ActualHours = jobDto.ActualHours;
            job.PercentUsed = jobDto.PercentUsed;
            job.EstToComplHours = jobDto.EstToComplHours;
            job.PercentComplete = jobDto.PercentComplete;
            job.DifferencePercent = jobDto.DifferencePercent;
            job.ForecastHours = jobDto.ForecastHours;
            job.VarianceHours = jobDto.VarianceHours;
            job.VariancePercent = jobDto.VariancePercent;

            return job;
        }

        public static JobDto ToJobDto(this JobModel jobModel)
        {
            var job = new JobDto();
            
            job.JobId = jobModel.JobId;
            job.JobNo = jobModel.JobNo;
            job.JobName = jobModel.JobName;
            job.Description = jobModel.Description;
            job.StartDate = jobModel.StartDate;
            job.DueDate = jobModel.DueDate;
            job.StatusID = jobModel.StatusID;
            job.JobCategory = jobModel.JobCategory;
            job.ManageVisaISR = jobModel.ManageVisaISR;
            job.ClientID = jobModel.ClientID;
            job.BusinessUnitID = jobModel.BusinessUnitID;
            job.WFMId = jobModel.WFMId;
            job.WFMLastUpdate = jobModel.WFMLastUpdate;
            job.LastUpdate = jobModel.LastUpdate;
            job.ProjectMangerID = jobModel.ProjectMangerID;
            job.AccountManagerID = jobModel.AccountManagerID;
            job.QuotedHours = jobModel.QuotedHours;
            job.ActualHours = jobModel.ActualHours;
            job.PercentUsed = jobModel.PercentUsed;
            job.EstToComplHours = jobModel.EstToComplHours;
            job.PercentComplete = jobModel.PercentComplete;
            job.DifferencePercent = jobModel.DifferencePercent;
            job.ForecastHours = jobModel.ForecastHours;
            job.VarianceHours = jobModel.VarianceHours;
            job.VariancePercent = jobModel.VariancePercent;
            
            return job;
        }

    }
}
