using BusinessLogic;
using DataMigrations.DataModels;
using ISRDataAccess.Models;


namespace ISRDataAccess.Extentions
{
    public static class TaskExtention
    {
        public static TaskModel ToTaskModel(this SingleTask task)
        {
            var qh = Convert.ToDecimal(task.EstimatedMinutes) * 60;
            var ah = Convert.ToDecimal(task.ActualMinutes) * 60;

            var taskModel = new TaskModel()
            {
                 
               
                UUID = task.UUID,
                TaskName = task.Name,
                LastUpdate = DateTime.Now,
                QuotedHours =qh,
                ActualHours = ah,
                PercentUsed =ah/qh ,
                EstToComplHours = 0,
                ForecastHours = qh+ah,
                
            };

            return taskModel;
        }

        public static SingleTask ToTasks(this TaskModel task)
        {
            var tasks = new SingleTask()
            {
               
               
            };

            return tasks;
        }
    }
}
