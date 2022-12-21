
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
            var jobModel = (from job in _db.Jobs
                            join taskGroup in
                                 (
                                     from task in _db.Tasks
                                     where task.EstToComplHours == null && task.ActualHours != null
                                     group task by task.JobId into tg
                                     select new
                                     {
                                         id = tg.Key,
                                         count = tg.Count()
                                     }
                                 ) on job.Id equals taskGroup.id into j
                            from tasks in j.DefaultIfEmpty()
                            select new JobModel
                            {
                                Id = job.Id,
                                JobId = job.JobNo,
                                UUID = job.UUID,
                                JobName = job.JobName,
                                ClientName = job.ClientName,
                                ProjectManger = job.ProjectManger,
                                SDM = job.SDM,
                                ProjectStatus = job.ProjectStatus,
                                QuotedHours = job.QuotedHours,
                                ActualHours = job.ActualHours,
                                StartDate = job.StartDate,
                                DueDate = job.DueDate,
                                WFMLastUpdate = job.WFMLastUpdate,
                                CurrentQuotedHoursUsed = job.CurrentQuotedHoursUsed,
                                EstToComplHours = job.EstToComplHours,
                                TotalForeCastHours = job.TotalForeCastHours,
                                CurrentthroughProject = job.CurrentthroughProject,
                                ForecastQuotedHours = job.ForecastQuotedHours,
                                TaskCompletePending = Convert.ToBoolean(tasks.count == null),
                                isLock = job.IsLock,

                            }).ToList();


            return jobModel;
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

        public int UpdateJobestToComplite(decimal? currentquotedhoursUsed, decimal? forecastquoteHours, decimal? estimatetocomplite, decimal? totalforecostHours, decimal? CurrentprecentTroughProject, int jobid)
        {
            Job jobexists = _db.Jobs.Where(x => x.Id == jobid).FirstOrDefault();
            Job extjob = new Job();
            extjob = jobexists;
            if (jobexists != null)
            {
                jobexists.EstToComplHours = estimatetocomplite;
                jobexists.TotalForeCastHours = totalforecostHours;
                jobexists.CurrentthroughProject = CurrentprecentTroughProject;
                //  jobexists.CurrentQuotedHoursUsed = currentquotedhoursUsed;
                jobexists.ForecastQuotedHours = forecastquoteHours;
                _db.Entry(extjob).CurrentValues.SetValues(jobexists);
                _db.SaveChanges();

            }
            return extjob.Id;


        }

        public int UpdateIslock(int jobid, bool? islock)
        {
            Job jobexists = _db.Jobs.Where(x => x.Id == jobid).FirstOrDefault();
            if (jobexists != null)
            {
                jobexists.IsLock = islock;
                _db.Entry(jobexists).CurrentValues.SetValues(jobexists);
                _db.SaveChanges();
            }
            return jobid;
        }

        public bool? CheckIslock(string UUID)
        {
           
            var jobexists = _db.Jobs.Where(x => x.UUID == UUID).FirstOrDefault();
            if (jobexists!=null)
            {
                return jobexists.IsLock;
              
            }
            return null;
        }
    }
}
