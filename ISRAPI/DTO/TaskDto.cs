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
        public decimal? TotalForecastHours { get; set; }

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
                CurrentQuoteHoursUsed = taskdto.PercentUsed,
                TotalForecastHours = taskdto.TotalForecastHours,
                TaskId = taskdto.TaskId,
                EstToComplHours = taskdto.EstToComplHours,
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
                PercentUsed = taskModel.CurrentQuoteHoursUsed,
                TotalForecastHours = taskModel.TotalForecastHours,
                EstToComplHours = taskModel.EstToComplHours,
                TaskId = taskModel.TaskId,
            };
            return job;
        }
        public static TaskModel ToTaskModelFromWFM(this SingleTask task, int jobid)
        {
            Decimal qh = 0;
            Decimal ah = 0;

            qh = Convert.ToDecimal(task.EstimatedMinutes) / 60;
            ah = Convert.ToDecimal(task.ActualMinutes) / 60;
            var taskModel = new TaskModel();

            if (qh != 0 && ah == 0)
            {
                taskModel = new TaskModel()
                {
                    UUID = task.UUID,
                    TaskName = task.Name,
                    LastUpdate = DateTime.Now,
                    QuotedHours = qh,
                    ActualHours = null,
                    CurrentQuoteHoursUsed = ah,
                    EstToComplHours = null,
                    TotalForecastHours = qh,
                    JobId = jobid,
                };
            }
            else if (qh != 0 && ah != 0)
            {
                taskModel = new TaskModel()
                {
                    UUID = task.UUID,
                    TaskName = task.Name,
                    LastUpdate = DateTime.Now,
                    QuotedHours = qh,
                    ActualHours = ah,
                    CurrentQuoteHoursUsed = ah/qh,
                    EstToComplHours = null,
                    TotalForecastHours = null,
                    JobId = jobid,

                };
            }
            else if (qh == 0 && ah != 0)
            {
                taskModel = new TaskModel()
                {
                    UUID = task.UUID,
                    TaskName = task.Name,
                    LastUpdate = DateTime.Now,
                    QuotedHours = null,
                    ActualHours = ah,
                    CurrentQuoteHoursUsed = null,
                    EstToComplHours = null,
                    TotalForecastHours = null,
                    JobId = jobid,
                };
            }
            
            return taskModel;
        }

        public static decimal? TotalForecastHours(decimal? qh, decimal? ah, decimal? tocomplitehours)
        {
            decimal? totoalForecastHours = null;

            if (qh != null && ah != null)
            {
                totoalForecastHours = null;
            }
            else if (qh != null && ah == null)
            {
                totoalForecastHours = qh;
            }
            else if (qh != null && ah == null && tocomplitehours != null)
            {
                totoalForecastHours = tocomplitehours;
            }
            else if (qh != null && ah != null && tocomplitehours != null)
            {
                totoalForecastHours = tocomplitehours + ah;
            }


            return totoalForecastHours;
        }
    }
}


