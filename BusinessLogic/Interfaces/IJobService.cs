using BusinessLogic.Models;
using ISRDataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IJobService
    {
        ServiceResponse<JobModel> GetJobById(int roleId);
        ServiceResponse<IList<JobModel>> GetAllJob();
        ServiceResponse<int> AddJob(Job item);
        ServiceResponse<int> UpdateHours(decimal actualHours, decimal quotedHours, string UUID);
    }
}