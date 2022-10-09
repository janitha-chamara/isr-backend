using BusinessLogic;
using DataMigrations.DataModels;
using ISRDataAccess.Models;


namespace ISRDataAccess.Extentions
{
    public static class TaskExtention
    {
        public static TaskModel ToTaskModel(this SingleTask task)
        {
            var qh = Convert.ToDecimal(task.EstimatedMinutes) ;
            var ah = Convert.ToDecimal(task.ActualMinutes);

            var taskModel = new TaskModel()
            {
                 
               
                UUID = task.UUID,
                TaskName = task.Name,
                LastUpdate = DateTime.Now,
                QuotedHours =qh,
                ActualHours = ah,
                CurrentQuoteHoursUsed =ah/qh ,
                EstToComplHours = 0,
                TotalForecastHours = qh+ah,
                
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
