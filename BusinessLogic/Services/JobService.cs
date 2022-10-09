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
            if (job.contact == null)
            {
                Contact contact = new Contact();
                job.contact = contact;
            }

            if (job.manager == null)
            {
                Manager manager = new Manager();
                job.manager = manager;
            }

            decimal actualHours = 60;
            decimal quotedHours = 60;
            decimal ForeCastHours = 60;


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
                QuotedHours = actualHours / 60,
                ActualHours = quotedHours / 60,
                CurrentQuotedHoursUsed = (actualHours / quotedHours) * 100,
                CurrentthroughProject = 0,
                EstToComplHours = ForeCastHours/60,
                ForecastQuotedHours = 0,
                ProjectStatus = job.State,
                TotalForeCastHours = (actualHours + ForeCastHours) * 100,
            };

            int jobid = _jobDal.AddJobs(jobmode);
            return new ServiceResponse<int>(jobid);
        }

        public ServiceResponse<int> UpdateHours(decimal? actualHours, decimal? quotedHours, string UUID)
        {
            if (quotedHours == 0)
            {
                quotedHours = actualHours;
            }
            if (actualHours == 0)
            {
                actualHours = quotedHours;
            }
            if (actualHours == 0 && quotedHours == 0)
            {
                actualHours = 60;
                quotedHours = 60;
            }
            var jobmode = new JobModel()
            {
                UUID = UUID,
                QuotedHours = quotedHours / 60,
                ActualHours = actualHours / 60,
                CurrentQuotedHoursUsed = (actualHours / quotedHours) * 100,
                CurrentthroughProject = 0,
                EstToComplHours = 0,
                ForecastQuotedHours = (actualHours / quotedHours) * 100,
                TotalForeCastHours = actualHours / 60,
            };
            int jobid = _jobDal.AddJobs(jobmode);
            return new ServiceResponse<int>(jobid);
        }

        public ServiceResponse<int> UpdateEstimatetoComplete(decimal? forecastquoteHours, decimal? estimatetocomplite, decimal? totalforecostHours, decimal? CurrentprecentTroughProject, int jobid)
        {
            int id = _jobDal.UpdateJobestToComplite(forecastquoteHours, estimatetocomplite, totalforecostHours, CurrentprecentTroughProject, jobid);
            return new ServiceResponse<int>(id);
        }


    }

}
