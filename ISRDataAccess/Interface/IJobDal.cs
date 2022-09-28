using DataMigrations.DataModels;
using ISRDataAccess.Models;

namespace ISRDataAccess.Services
{
    public interface IJobDal
    {
        JobModel GetJobById(int id);
        IList<Models.JobModel> GetAllJob();

        int AddJobs(JobModel job);
    }
}