
using Data.DataAccess.Interfaces;
using Data.DataAccess.Services;
using DataMigrations.DataModels;
using ISRDataAccess.Extentions;
using ISRDataAccess.Models;
using System.Collections.Generic;

namespace ISRDataAccess.Services
{
    public class JobDal : BaseDal ,IJobDal
    {
        public Models.JobModel GetJobById(int id)
        {
            var result = _db.Jobs.FirstOrDefault(d => d.JobId == id);

            return result.ToJobModel();
        }

        public IList <Models.JobModel> GetAllJob()
        {
            var result = _db.Jobs;

            return result.Select(x => x.ToJobModel()).ToList();
        }
    }
}
