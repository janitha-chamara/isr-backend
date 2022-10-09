using Data.DataAccess.Services;
using DataMigrations.DataModels;
using ISRDataAccess.Extentions;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ISRDataAccess.Services
{
    public class TaskDal : BaseDal, ITaskDal
    {
        public IList<TaskModel> GetTaskByJobId(int id)
        {
            var result = _db.Tasks;
            var results = result.Where(x => x.JobId == id);
            return results.Select(x => x.ToTaskModel()).ToList();
        }

        public int AddTask(TaskModel task)
        {
            Tasks newtasks = task.ToTasks();
            Tasks taskmode = _db.Tasks.Where(x => x.UUID == task.UUID).FirstOrDefault();
            if (taskmode != null)
            {
                taskmode = newtasks;
                return taskmode.Id;
            }
            else
            {
                _db.Tasks.Add(newtasks);
                _db.SaveChanges();
                return newtasks.Id;
            }
        }

        public void AddTasks(List<TaskModel> tasks)
        {
            List<Tasks> tasklist = tasks.Select(d => d.ToTasks()).ToList();
            _db.Tasks.AddRange(tasklist);
            _db.SaveChanges();

        }
        public int UpdateTask(TaskModel task)
        {
            Tasks newTask = task.ToTasks();
            Tasks Taskexists = _db.Tasks.Where(x => x.UUID == newTask.UUID).FirstOrDefault();

            if (Taskexists != null)
            {
                _db.Entry(Taskexists).CurrentValues.SetValues(newTask);
                _db.SaveChanges();
                return Taskexists.Id;
            }
            else
            {
                _db.Tasks.Add(newTask);
                _db.SaveChanges();
                return newTask.Id;
            }


        }

        public int UpdateTaskFromWFM(TaskModel task)
        {
            Tasks newTask = task.ToTasks();
            Tasks Taskexists = _db.Tasks.Where(x => x.UUID == newTask.UUID).FirstOrDefault();
            Tasks ExtTasks = new Tasks();
            ExtTasks = Taskexists;
            if (Taskexists != null)
            {
                //Taskexists.EstToComplHours = newTask.EstToComplHours;
                Taskexists.TotalForecastHours = newTask.TotalForecastHours;
                Taskexists.EstToComplHours = ExtTasks.EstToComplHours;
                _db.Entry(ExtTasks).CurrentValues.SetValues(Taskexists);
                _db.SaveChanges();
                return Taskexists.Id;
            }
            else
            {
                _db.Tasks.Add(newTask);
                _db.SaveChanges();
                return newTask.Id;
            }


        }
    }
}
