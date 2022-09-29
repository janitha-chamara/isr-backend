using Data.DataAccess.Services;
using ISRDataAccess.Extentions;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
