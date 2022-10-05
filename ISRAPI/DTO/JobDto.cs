﻿

using ISRDataAccess.Models;

namespace ISRAPI
{
    public class JobDto
    {
        public int Id { get; set; }
        public string JobId { get; set; }
        public string JobName { get; set; }
        public string ClientName { get; set; }
        public string ProjectManger { get; set; }
        public string SDM { get; set; }
        public string ProjectStatus { get; set; }
        public decimal QuotedHours { get; set; }
        public decimal ActualHours { get; set; }
        public decimal CurrentQuotedHoursUsed { get; set; }
        public decimal EstToComplHours { get; set; }
        public decimal TotalForeCastHours { get; set; }
        public decimal CurrentthroughProject { get; set; }
        public decimal ForecastQuotedHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public static class JobDtoMapExtensions
    {
        public static JobModel ToJobModel(this JobDto jobDto)
        {
            var dst = new JobModel()
            {
                JobId = jobDto.JobId,
                JobName = jobDto.JobName,
                ClientName = jobDto.ClientName,
                ProjectManger = jobDto.ProjectManger,
                SDM = jobDto.SDM,
                ProjectStatus = jobDto.ProjectStatus,
                QuotedHours = jobDto.QuotedHours,
                ActualHours = jobDto.ActualHours,
                CurrentQuotedHoursUsed = jobDto.CurrentQuotedHoursUsed,
                EstToComplHours = jobDto.EstToComplHours,
                TotalForeCastHours = jobDto.TotalForeCastHours,
                CurrentthroughProject = jobDto.CurrentthroughProject,
                ForecastQuotedHours = jobDto.ForecastQuotedHours,
                EndDate = jobDto.EndDate,
                StartDate = jobDto.StartDate,


            };


            return dst;
        }

        public static JobDto ToJobDto(this JobModel jobModel)
        {
            var job = new JobDto()
            {
                Id = jobModel.Id,
                JobName = jobModel.JobName,
                ClientName = jobModel.ClientName,
                ProjectManger = jobModel.ProjectManger,
                SDM = jobModel.SDM,
                ProjectStatus = jobModel.ProjectStatus,
                QuotedHours = jobModel.QuotedHours,
                ActualHours = jobModel.ActualHours,
                CurrentQuotedHoursUsed = jobModel.CurrentQuotedHoursUsed,
                EstToComplHours = jobModel.EstToComplHours,
                TotalForeCastHours = jobModel.TotalForeCastHours,
                CurrentthroughProject = jobModel.CurrentthroughProject,
                ForecastQuotedHours = jobModel.ForecastQuotedHours,

            };



            return job;
        }

    }
}
