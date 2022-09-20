namespace ISRDataAccess.Extentions
{
    using DataMigrations.DataModels;
    using ISRDataAccess.Models;

    public static class JobExtention
    {
        public static JobModel ToJobModel(this Job job)
        {
            var dst = new JobModel();

            dst.JobNo = job.JobNo;
            dst.JobId = job.JobId;  
            dst.JobName = job.JobName;
            dst.StatusID = job.StatusID;
            dst.Description = job.Description;
            dst.DueDate = job.DueDate;
            dst.StartDate = job.StartDate;
            dst.LastUpdate = job.LastUpdate;
            dst.WFMLastUpdate = job.WFMLastUpdate;
            dst.DifferencePercent = job.DifferencePercent;
            dst.EstToComplHours = job.EstToComplHours;


            return dst;
        }

       

    }
}
