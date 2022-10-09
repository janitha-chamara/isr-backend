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
                CurrentQuoteHoursUsed =task.CurrentofQuotedHoursUsed,
                EstToComplHours = task.EstToComplHours,
                TotalForecastHours = task.TotalForecastHours,
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
                CurrentofQuotedHoursUsed = task.CurrentQuoteHoursUsed,
                EstToComplHours = task.EstToComplHours,
                TotalForecastHours = task.TotalForecastHours,
            };

            return tasks;
        }
    }
}
