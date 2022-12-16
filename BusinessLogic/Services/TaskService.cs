using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;
namespace BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskDal _taskDal;
        public TaskService(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }
        public ServiceResponse<int> AddTask(TaskModel task)
        {
            
            int taskId = _taskDal.AddTask(task);
            return new ServiceResponse<int>(taskId);
        }
        public ServiceResponse<IList<TaskModel>> GetTaskByJobId(int jobid)
        {
            return new ServiceResponse<IList<TaskModel>>(_taskDal.GetTaskByJobId(jobid));
        }

        public ServiceResponse<int> UpdateTask(TaskModel taskModel)
        {
            return new ServiceResponse<int>(_taskDal.UpdateTask(taskModel));
        }

        public ServiceResponse<int> UpdateTaskFromWFM(TaskModel taskModel)
        {
            return new ServiceResponse<int>(_taskDal.UpdateTaskFromWFM(taskModel));
        }

        public ServiceResponse<decimal?> GetEstMatetoCompletedHours(string UUID)
        {
            return new ServiceResponse<decimal?>(_taskDal.GetEstMatetoCompletedHours(UUID));

        }

    }
}