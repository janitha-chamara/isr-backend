using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskDal _taskDal;
        public TaskService(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }
        public ServiceResponse<int> AddTask(TaskModel taskModel)
        {
            int taskId = _taskDal.AddTask(taskModel);
            return new ServiceResponse<int>(taskId);
        }
        public ServiceResponse<IList<TaskModel>> GetTaskByJobId(int jobid)
        {
            return new ServiceResponse<IList<TaskModel>>(_taskDal.GetTaskByJobId(jobid));
        }

        //public ServiceResponse<IList<TaskModel>>UpdateTask(TaskModel taskModel)
        //{
        //    return new ServiceResponse<IList<TaskModel>>(_taskDal.Update)
        //}
        

    }
}