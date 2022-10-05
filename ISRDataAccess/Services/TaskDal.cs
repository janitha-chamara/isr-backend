using Data.DataAccess.Services;
using DataMigrations.DataModels;
using ISRDataAccess.Extentions;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;
namespace ISRDataAccess.Services
{
    public class TaskDal : BaseDal, ITaskDal
    {
        public IList<TaskModel> GetTaskByJobId(int id)
        {
            var result = _db.Tasks;
            var results = result.Select(x => x.JobId == id);
            return result.Select(x => x.ToTaskModel()).ToList();
        }

        public int AddTask(TaskModel task)
        {
            Tasks newtasks = task.ToTasks();
            _db.Tasks.Add(newtasks);
            _db.SaveChanges();
            return newtasks.Id;
        }

        public void AddTasks(List<TaskModel> tasks)
        {
           List<Tasks> tasklist = tasks.Select(d => d.ToTasks()).ToList();
            _db.Tasks.AddRange(tasklist);
            _db.SaveChanges();
           
        }


    }
}
