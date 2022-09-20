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
        public ServiceResponse<JobModel> GetJobById(int roleId)
        {
            return new ServiceResponse<JobModel>(_jobDal.GetJobById(roleId));
        }

        public ServiceResponse<IList<JobModel>> GetAllJob()
        {
            var allJobs = _jobDal.GetAllJob();
            return new ServiceResponse<IList<JobModel>>(allJobs);
        }
    }

}
