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
                DueDate = job.DueDate,
                ProjectManger = job.manager.Name,
                SDM = job.partner.Name,
                ClientName = job.client.Name,
                QuotedHours = quotedHours / 60,
                ActualHours = actualHours / 60,
                CurrentQuotedHoursUsed = null,
                CurrentthroughProject = null,
                EstToComplHours = null,
                ForecastQuotedHours = null,
                ProjectStatus = job.State,
                TotalForeCastHours = null,
                WFMLastUpdate = DateTime.Now,
            };

            int jobid = _jobDal.AddJobs(jobmode);
            return new ServiceResponse<int>(jobid);
        }

        public ServiceResponse<int> UpdateHours(decimal? actualHours, decimal? quotedHours, Job job)
        {
            var jobmode = new JobModel();
            jobmode.SDM= job.partner.Name;
            jobmode.ClientName= job.client.Name;
            jobmode.ProjectManger = job.manager.Name;
            jobmode.ProjectStatus = job.State;
            jobmode.UUID = job.UUID;
            jobmode.WFMLastUpdate= DateTime.Now;
            if (quotedHours == 0 && actualHours!= 0)
            {
                jobmode.QuotedHours = quotedHours ;
                jobmode.ActualHours = actualHours ;
                jobmode.EstToComplHours = 0;
                jobmode.TotalForeCastHours = actualHours;
                jobmode.CurrentQuotedHoursUsed = null;
                jobmode.CurrentthroughProject = ((actualHours / actualHours)) * 100;
                jobmode.ForecastQuotedHours = null;

            }
            else if (actualHours == 0 && quotedHours!=0)
            {
                jobmode.QuotedHours = quotedHours ;
                jobmode.ActualHours = actualHours ;
                jobmode.EstToComplHours = 0;
                jobmode.TotalForeCastHours = 0;
                jobmode.CurrentQuotedHoursUsed = 0;
                jobmode.CurrentthroughProject = null;
                jobmode.ForecastQuotedHours = 0;
            }
            else if (actualHours == 0 && quotedHours == 0)
            {
                jobmode.QuotedHours = null;
                jobmode.ActualHours = null;
                jobmode.CurrentQuotedHoursUsed = null;
                jobmode.EstToComplHours = null;
                jobmode.TotalForeCastHours = null;
                jobmode.CurrentQuotedHoursUsed = null;
                jobmode.CurrentthroughProject = null;
                jobmode.ForecastQuotedHours = null;
            }
            else 
            {
                jobmode.QuotedHours = quotedHours ;
                jobmode.ActualHours = actualHours ;
                jobmode.EstToComplHours = 0;
                jobmode.TotalForeCastHours = actualHours;
                jobmode.CurrentQuotedHoursUsed = ((actualHours / quotedHours) ) * 100;
                jobmode.CurrentthroughProject = (((((jobmode.TotalForeCastHours)) - 0) / jobmode.TotalForeCastHours) / 60) * 100;
                jobmode.ForecastQuotedHours = ((jobmode.TotalForeCastHours / quotedHours)) * 100;
            }

            int jobid = _jobDal.AddJobs(jobmode);
            return new ServiceResponse<int>(jobid);
        }

        public ServiceResponse<int> UpdateEstimatetoComplete(decimal? currentquotedhoursUsed, decimal? forecastquoteHours, decimal? estimatetocomplite, decimal? totalforecostHours, decimal? CurrentprecentTroughProject, int jobid)
        {
            int id = _jobDal.UpdateJobestToComplite(currentquotedhoursUsed,forecastquoteHours, estimatetocomplite, totalforecostHours, CurrentprecentTroughProject, jobid);
            return new ServiceResponse<int>(id);
        }

        public ServiceResponse<int> UpdateIslock(int jobid,bool? islock)
        {
            int id = _jobDal.UpdateIslock(jobid,islock);
            return new ServiceResponse<int>(id);
        }
    }

}
