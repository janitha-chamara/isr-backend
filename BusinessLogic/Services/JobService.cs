using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using ISRDataAccess.Models;
using ISRDataAccess.Services;

namespace BusinessLogic.Services
{
    public class JobService : IJobService
    {
        private readonly IJobDal _jobDal;

        public JobService(IJobDal jobDal)
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

        public ServiceResponse<int> AddJob(Job job)
        {

            var jobmode = new JobModel()
            {
                UUID = job.UUID,
                JobId = job.Id,
                JobName = job.Name,
                StartDate = job.StartDate,
                EndDate = job.DueDate,
                ProjectManger = job.manager.Name,
                SDM = job.contact.Name,
                ClientName = job.client.Name,
                QuotedHours = 0,
                ActualHours = 0,
                CurrentQuotedHoursUsed = 0,
                CurrentthroughProject = 0,
                EstToComplHours = 0,
                ForecastQuotedHours = 0,
                ProjectStatus = job.State,
                TotalForeCastHours = 0,
            };

            int jobid = _jobDal.AddJobs(jobmode);
            return new ServiceResponse<int>(jobid);
        }
    }

}
