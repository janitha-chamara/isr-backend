using BusinessLogic.Models;
using ISRDataAccess.Models;

namespace BusinessLogic.Services
{
    public interface IJobService
    {
        ServiceResponse<JobModel> GetJobById(int roleId);
        ServiceResponse<IList<JobModel>> GetAllJob();
    }
}