using ISRDataAccess.Models;

namespace ISRAPI
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public int JobId { get; set; }
        public string UUID { get; set; }
        public int TaskName { get; set; }
        public DateTime LastUpdate { get; set; }
        public decimal QuotedHours { get; set; }
        public decimal ActualHours { get; set; }
        public decimal PercentUsed { get; set; }
        public decimal EstToComplHours { get; set; }
        public decimal PercentComplete { get; set; }
        public decimal DifferencePercent { get; set; }
        public decimal ForecastHours { get; set; }
        public decimal VarianceHours { get; set; }
        public decimal VariancePercent { get; set; }
        public decimal Weighting { get; set; }
    }

    public static class TasksDtoMapExtensions
    {
        public static TaskModel ToTaskModel(this TaskDto taskModel)
        {
            var task = new TaskModel();

            task.TaskId = taskModel.TaskId;
            task.JobId = taskModel.JobId;
            task.UUID = taskModel.UUID;
            task.TaskName = taskModel.TaskName;
            task.LastUpdate = taskModel.LastUpdate;
            task.QuotedHours = taskModel.QuotedHours;
            task.ActualHours = taskModel.ActualHours;
            task.PercentUsed = taskModel.PercentUsed;
            task.EstToComplHours = taskModel.EstToComplHours;
            task.PercentComplete = taskModel.PercentComplete;
            task.DifferencePercent = taskModel.DifferencePercent;
            task.ForecastHours = taskModel.ForecastHours;
            task.VarianceHours = taskModel.VarianceHours;
            task.VariancePercent = taskModel.VariancePercent;
            task.Weighting = taskModel.Weighting;


            return task;
        }

        public static TaskDto ToTaskDto(this TaskModel taskModel)
        {
            var task = new TaskDto();

            task.TaskId = taskModel.TaskId;
            task.JobId = taskModel.JobId;
            task.UUID = taskModel.UUID;
            task.TaskName = taskModel.TaskName;
            task.LastUpdate = taskModel.LastUpdate;
            task.QuotedHours = taskModel.QuotedHours;
            task.ActualHours = taskModel.ActualHours;
            task.PercentUsed = taskModel.PercentUsed;
            task.EstToComplHours = taskModel.EstToComplHours;
            task.PercentComplete = taskModel.PercentComplete;
            task.DifferencePercent = taskModel.DifferencePercent;
            task.ForecastHours = taskModel.ForecastHours;
            task.VarianceHours = taskModel.VarianceHours;
            task.VariancePercent = taskModel.VariancePercent;
            task.Weighting = taskModel.Weighting;



            return task;
        }

    }
}
