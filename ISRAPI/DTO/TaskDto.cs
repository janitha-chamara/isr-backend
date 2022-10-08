using BusinessLogic;
using ISRDataAccess.Models;

namespace ISRDataAccess.Models
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public int JobId { get; set; }
        public string UUID { get; set; }
        public string? TaskName { get; set; }
        public DateTime? LastUpdate { get; set; }
        public decimal? QuotedHours { get; set; }
        public decimal? ActualHours { get; set; }
        public decimal? PercentUsed { get; set; }
        public decimal? EstToComplHours { get; set; }
        public decimal? PercentComplete { get; set; }
        public decimal? DifferencePercent { get; set; }
        public decimal? ForecastHours { get; set; }
        public decimal? VarianceHours { get; set; }
        public decimal? VariancePercent { get; set; }
        public decimal? Weighting { get; set; }
    }
    public static class TaskDtoMapExtensions
    {
        public static TaskModel ToTaskModel(this TaskDto taskdto)
        {
            var dst = new TaskModel()
            {
                JobId = taskdto.JobId,
                UUID = taskdto.UUID,
                TaskName = taskdto.TaskName,
                LastUpdate = taskdto.LastUpdate,
                QuotedHours = taskdto.QuotedHours,
                ActualHours = taskdto.ActualHours,
                PercentUsed = taskdto.PercentUsed,
                DifferencePercent = taskdto.DifferencePercent,
                ForecastHours = taskdto.ForecastHours,
                VarianceHours = taskdto.VarianceHours,
                VariancePercent = taskdto.VariancePercent,
                TaskId = taskdto.TaskId,
            };
            return dst;
        }

        public static TaskDto ToTaskDto(this TaskModel taskModel)
        {
            var job = new TaskDto()
            {
                JobId = taskModel.JobId,
                UUID = taskModel.UUID,
                TaskName = taskModel.TaskName,
                LastUpdate = taskModel.LastUpdate,
                QuotedHours = taskModel.QuotedHours,
                ActualHours = taskModel.ActualHours,
                PercentUsed = taskModel.PercentUsed,
                DifferencePercent = taskModel.DifferencePercent,
                ForecastHours = taskModel.ForecastHours,
                VarianceHours = taskModel.VarianceHours,
                VariancePercent = taskModel.VariancePercent,
                TaskId = taskModel.TaskId,
            };
            return job;
        }
        public static TaskModel ToTaskModelFromWFM(this SingleTask task, int jobid)
        {
            Decimal qh = 0;
            Decimal ah = 0;

            if (task.EstimatedMinutes == "0")
            {
                task.EstimatedMinutes = "1";
                qh = Convert.ToDecimal(task.EstimatedMinutes) / 60;
            }

            if (task.ActualMinutes == "0")
            {
                task.ActualMinutes = "1";
                ah = Convert.ToDecimal(task.ActualMinutes) / 60;
            }
            qh = Convert.ToDecimal(task.EstimatedMinutes) / 60;
            ah = Convert.ToDecimal(task.ActualMinutes) / 60;

            var taskModel = new TaskModel()
            {
                UUID = task.UUID,
                TaskName = task.Name,
                LastUpdate = DateTime.Now,
                QuotedHours = qh,
                ActualHours = ah,
                PercentUsed = ah / qh,
                EstToComplHours = 0,
                ForecastHours = qh + ah,
               // VarianceHours = 0,
               // VariancePercent = 0,
               // DifferencePercent = 0,
                JobId = jobid,
              //  PercentComplete = 0,

            };

            return taskModel;
        }
    }
}


