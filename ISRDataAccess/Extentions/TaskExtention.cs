using DataMigrations.DataModels;
using ISRDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRDataAccess.Extentions
{
    public static class TaskExtention
    {
        public static TaskModel ToTaskModel(this Tasks task)
        {
            var taskModel = new TaskModel()
            {
                TaskId = task.Id,
                JobId = task.JobId,
                UUID = task.UUID,
                TaskName = task.TaskName,
                LastUpdate = task.LastUpdate,
                QuotedHours = task.QuotedHours,
                ActualHours = task.ActualHours,
                PercentUsed = task.PercentUsed,
                EstToComplHours = task.EstToComplHours,
                
            };

            return taskModel;
        }

        public static Tasks ToTasks(this TaskModel task)
        {
            var tasks = new Tasks()
            {
                Id = task.TaskId,
                JobId = task.JobId,
                UUID = task.UUID,
                TaskName = task.TaskName,
                LastUpdate = task.LastUpdate,
                QuotedHours = task.QuotedHours,
                ActualHours = task.ActualHours,
                PercentUsed = task.PercentUsed,
                EstToComplHours = task.EstToComplHours,
               
            };

            return tasks;
        }
    }
}
