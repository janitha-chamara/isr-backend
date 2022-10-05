using ISRDataAccess.Models;

namespace ISRDataAccess.Models
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public int JobId { get; set; }
        public string UUID { get; set; }
        public string TaskName { get; set; }
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
                Weighting = taskdto.Weighting,
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
                Weighting = taskModel.Weighting,
                TaskId = taskModel.TaskId,
            };
            return job;
        }
    }
}


