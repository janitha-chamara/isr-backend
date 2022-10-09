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
                JobId = job.JobNo,
                JobName = job.JobName,
                StartDate = job.StartDate,
                EndDate = job.DueDate,
                ClientName = job.ClientName,
                UUID = job.UUID,
                ProjectManger = job.ProjectManger,
                SDM = job.SDM,
                QuotedHours = job.QuotedHours,
                ActualHours = job.ActualHours,
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
                DueDate = job.EndDate,
                ProjectManger = job.ProjectManger,
                WFMLastUpdate = DateTime.Now,
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