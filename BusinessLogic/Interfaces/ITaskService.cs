using BusinessLogic.Models;
using ISRDataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        ServiceResponse<int> AddTask(TaskModel taskModel);
        ServiceResponse<IList<TaskModel>> GetTaskByJobId(int id);
    }
}
