using BusinessLogic.Models;
using ISRDataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IJobService
    {
        ServiceResponse<JobModel> GetJobById(int roleId);
        ServiceResponse<IList<JobModel>> GetAllJob();

        ServiceResponse<int> AddJob(JobModel jobModel);
    }
}