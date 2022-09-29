using BusinessLogic.Interfaces;
using BusinessLogic.Model;
using BusinessLogic.Models;
using ISRDataAccess.Models;
using ISRDataAccess.Services;

namespace BusinessLogic.Services
{
    public class JobService : IJobService
    {
        private readonly IJobDal _jobDal;
        
        public JobService (IJobDal jobDal)
        {
            _jobDal = jobDal;
        }
        public ServiceResponse<JobModel> GetJobById(int id)
        {
            return new ServiceResponse<JobModel>(_jobDal.GetJobById(id));
        }

        public ServiceResponse<IList<JobModel>> GetAllJob()
        {
            var allJobs = _jobDal.GetAllJob();
            return new ServiceResponse<IList<JobModel>>(allJobs);
        }

        public ServiceResponse <int> AddJob(JobModel jobModel)
        {
            int jobid = _jobDal.AddJobs(jobModel);
                return new ServiceResponse<int>(jobid);
        }
    }

}
