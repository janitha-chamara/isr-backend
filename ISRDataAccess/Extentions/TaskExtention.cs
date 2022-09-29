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
                TaskId = task.TaskId,
                JobId = task.JobId,
                UUID = task.UUID,
                TaskName = task.TaskName,
                LastUpdate = task.LastUpdate,
                QuotedHours = task.QuotedHours,
                ActualHours = task.ActualHours,
                PercentUsed = task.PercentUsed,
                EstToComplHours = task.EstToComplHours,
                PercentComplete = task.PercentComplete,
                DifferencePercent = task.DifferencePercent,
                ForecastHours = task.ForecastHours,
                VarianceHours = task.VarianceHours,
                VariancePercent = task.VariancePercent,
                Weighting = task.Weighting,
            };

            return taskModel;
        }

        public static Tasks ToTask(this TaskModel task)
        {
            var taskModel = new Tasks()
            {
                TaskId = task.TaskId,
                JobId = task.JobId,
                UUID = task.UUID,
                TaskName = task.TaskName,
                LastUpdate = task.LastUpdate,
                QuotedHours = task.QuotedHours,
                ActualHours = task.ActualHours,
                PercentUsed = task.PercentUsed,
                EstToComplHours = task.EstToComplHours,
                PercentComplete = task.PercentComplete,
                DifferencePercent = task.DifferencePercent,
                ForecastHours = task.ForecastHours,
                VarianceHours = task.VarianceHours,
                VariancePercent = task.VariancePercent,
                Weighting = task.Weighting,
            };

            return taskModel;
        }
    }
}
