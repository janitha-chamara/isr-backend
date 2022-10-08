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
            if (job.contact ==null)
            {
                Contact contact = new Contact();
                job.contact = contact;
            }

            if (job.manager == null)
            {
                Manager manager = new Manager();
                job.manager  = manager;
            }

            decimal actualHours = 1;
            decimal quotedHours = 1;
            decimal ForeCastHours = 1;

           
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
                QuotedHours = actualHours,
                ActualHours = quotedHours,
                CurrentQuotedHoursUsed = actualHours/quotedHours,
                CurrentthroughProject = 0,
                EstToComplHours = ForeCastHours,
                ForecastQuotedHours = 0,
                ProjectStatus = job.State,
                TotalForeCastHours = actualHours+ForeCastHours,
            };

            int jobid = _jobDal.AddJobs(jobmode);
            return new ServiceResponse<int>(jobid);
        }

        public ServiceResponse<int>UpdateHours(decimal actualHours, decimal quotedHours, string UUID)
        {
            var jobmode = new JobModel()
            {
                UUID = UUID,
                QuotedHours = quotedHours,
                ActualHours = actualHours,
                CurrentQuotedHoursUsed=actualHours/quotedHours,
                CurrentthroughProject=0,
                EstToComplHours=0,
                ForecastQuotedHours=0,
                TotalForeCastHours=actualHours,
                
            };

            int jobid = _jobDal.AddJobs(jobmode);
            return new ServiceResponse<int>(jobid);
        }
    }

}
