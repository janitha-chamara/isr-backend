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
                JobId = job.JobId,
                JobNo = job.JobNo,
                JobName = job.JobName,
                Description = job.Description,
                StartDate = job.StartDate,
                DueDate = job.DueDate,
                StatusID = job.StatusID,
                JobCategory = job.JobCategory,
                ManageVisaISR = job.ManageVisaISR,
                ClientID = job.ClientID,
                BusinessUnitID = job.BusinessUnitID,
                WFMId = job.WFMId,
                WFMLastUpdate = job.WFMLastUpdate,
                LastUpdate = job.LastUpdate,
                ProjectMangerID = job.ProjectMangerID,
                AccountManagerID = job.AccountManagerID,
                QuotedHours = job.QuotedHours,
                ActualHours = job.ActualHours,
                PercentUsed = job.PercentUsed,
                EstToComplHours = job.EstToComplHours,
                PercentComplete = job.PercentComplete,
                DifferencePercent = job.DifferencePercent,
                ForecastHours = job.ForecastHours,
                VarianceHours = job.VarianceHours,
                VariancePercent = job.VariancePercent,
            };
            
            return dst;
        }

        public static Job ToJob(this JobModel job)
        {
            var dst = new Job
            {
                JobId = job.JobId,
                JobNo = job.JobNo,
                JobName = job.JobName,
                Description = job.Description,
                StartDate = job.StartDate,
                DueDate = job.DueDate,
                StatusID = job.StatusID,
                JobCategory = job.JobCategory,
                ManageVisaISR = job.ManageVisaISR,
                ClientID = job.ClientID,
                BusinessUnitID = job.BusinessUnitID,
                WFMId = job.WFMId,
                WFMLastUpdate = job.WFMLastUpdate,
                LastUpdate = job.LastUpdate,
                ProjectMangerID = job.ProjectMangerID,
                AccountManagerID = job.AccountManagerID,
                QuotedHours = job.QuotedHours,
                ActualHours = job.ActualHours,
                PercentUsed = job.PercentUsed,
                EstToComplHours = job.EstToComplHours,
                PercentComplete = job.PercentComplete,
                DifferencePercent = job.DifferencePercent,
                ForecastHours = job.ForecastHours,
                VarianceHours = job.VarianceHours,
                VariancePercent = job.VariancePercent,
            };

            return dst;
        }

    }
}
