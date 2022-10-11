
using Data.DataAccess.Interfaces;
using Data.DataAccess.Services;
using DataMigrations.DataModels;
using ISRDataAccess.Extentions;
using ISRDataAccess.Models;
using System.Collections.Generic;

namespace ISRDataAccess.Services
{
    public class JobDal : BaseDal, IJobDal
    {
        public Models.JobModel GetJobById(int id)
        {
            var result = _db.Jobs.FirstOrDefault(d => d.Id == id);

            return result.ToJobModel();
        }

        public IList<Models.JobModel> GetAllJob()
        {
            var result = _db.Jobs;
            return result.Select(x => x.ToJobModel()).ToList();
        }

        public int AddJobs(JobModel job)
        {
            Job newjob = job.ToJob();
            Job jobexists = _db.Jobs.Where(x => x.UUID == newjob.UUID).FirstOrDefault();
            Job extjob = new Job();
            extjob = jobexists;
            if (jobexists != null)
            {
                jobexists.ActualHours = newjob.ActualHours;
                jobexists.QuotedHours = newjob.QuotedHours;
                jobexists.SDM = newjob.SDM;
                jobexists.ClientName = newjob.ClientName;
                jobexists.ProjectManger = newjob.ProjectManger;
                jobexists.CurrentQuotedHoursUsed = newjob.CurrentQuotedHoursUsed;
                jobexists.TotalForeCastHours = newjob.TotalForeCastHours;
                jobexists.WFMLastUpdate = DateTime.Now;
                jobexists.ProjectStatus = newjob.ProjectStatus;
                _db.Entry(extjob).CurrentValues.SetValues(jobexists);
                _db.SaveChanges();
                return jobexists.Id;
            }

            else
            {
                _db.Jobs.Add(newjob);
                _db.SaveChanges();
                return newjob.Id;
            }


        }

        public int UpdateJobestToComplite(decimal? forecastquoteHours, decimal? estimatetocomplite, decimal? totalforecostHours, decimal? CurrentprecentTroughProject, int jobid)
        {
            Job jobexists = _db.Jobs.Where(x => x.Id == jobid).FirstOrDefault();
            Job extjob = new Job();
            extjob = jobexists;
            if (jobexists != null)
            {
                jobexists.EstToComplHours = estimatetocomplite;
                jobexists.TotalForeCastHours= totalforecostHours;
                jobexists.CurrentthroughProject = CurrentprecentTroughProject;
                jobexists.CurrentQuotedHoursUsed= forecastquoteHours;
                jobexists.ForecastQuotedHours = forecastquoteHours;
                _db.Entry(extjob).CurrentValues.SetValues(jobexists);
                _db.SaveChanges();

            }
            return extjob.Id;


        }


    }
}