using BusinessLogic.Models;
using ISRDataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        ServiceResponse<int> AddTask(TaskModel task);
        ServiceResponse<IList<TaskModel>> GetTaskByJobId(int id);
        ServiceResponse<int> UpdateTask(TaskModel taskModel);
        ServiceResponse<int> UpdateTaskFromWFM(TaskModel taskModel);
    }
}
