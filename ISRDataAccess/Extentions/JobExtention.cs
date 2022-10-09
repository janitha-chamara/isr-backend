namespace ISRDataAccess.Extentions
{
    using DataMigrations.DataModels;
    using Models;

    public static class JobExtention
    {
        public static JobModel ToJobModel(this Job job)
        {
            var dst = new JobModel
            {
                UUID = job.UUID,
                Id = job.Id,
                JobName = job.JobName,
                StartDate = job.StartDate,
                DueDate = job.DueDate,
                ProjectManger = job.ProjectManger,
                ProjectStatus = job.ProjectStatus,
                EstToComplHours = job.EstToComplHours,
                TotalForeCastHours = job.TotalForeCastHours,
                CurrentthroughProject = job.CurrentthroughProject,
                ForecastQuotedHours = job.ForecastQuotedHours,
                WFMLastUpdate = job.WFMLastUpdate,
                SDM = job.SDM,
                ClientName = job.ClientName,
                QuotedHours = job.QuotedHours,
                ActualHours = job.ActualHours,
                CurrentQuotedHoursUsed = job.CurrentQuotedHoursUsed,
            };

            return dst;
        }

        public static Job ToJob(this JobModel job)
        {
            var dst = new Job
            {
                UUID = job.UUID,
                JobNo = job.JobId,
                JobName = job.JobName,
                StartDate = job.StartDate,
                DueDate = job.DueDate,
                ProjectManger = job.ProjectManger,
                ProjectStatus = job.ProjectStatus,
                EstToComplHours = job.EstToComplHours,
                TotalForeCastHours = job.TotalForeCastHours,
                CurrentthroughProject = job.CurrentthroughProject,
                ForecastQuotedHours = job.ForecastQuotedHours,
                WFMLastUpdate = job.WFMLastUpdate,
                SDM = job.SDM,
                ClientName = job.ClientName,
                QuotedHours = job.QuotedHours,
                ActualHours = job.ActualHours,
                CurrentQuotedHoursUsed = job.CurrentQuotedHoursUsed,
            };

            return dst;
        }
    }
}