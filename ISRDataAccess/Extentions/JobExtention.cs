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
               //lientName = job.ClientId,
                UUID = job.UUID,
               //rojectManger = job.ProjectMangerID,
               //DM = job.AccountManagerID,
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
                JobNo=job.JobId,
                JobName=job.JobName,
                StartDate=job.StartDate,
                DueDate=job.EndDate,
                ProjectManger=job.ProjectManger,
                WFMLastUpdate= DateTime.Now,
                SDM=job.SDM,
                ClientName=job.ClientName,
                QuotedHours=job.QuotedHours,
                ActualHours=job.ActualHours,

            };

            return dst;
        }

    }
}
