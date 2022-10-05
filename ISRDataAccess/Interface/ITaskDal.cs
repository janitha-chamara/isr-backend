using ISRDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRDataAccess.Interface
{
   public interface ITaskDal
    {
        IList<TaskModel> GetTaskByJobId(int id);
        int AddTask(TaskModel task);
        void AddTasks(List<TaskModel> tasks);
    }
}
