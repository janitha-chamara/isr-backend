using ISRDataAccess.Models;

namespace ISRDataAccess.Services
{
    public interface IJobDal
    {
        JobModel GetJobById(int id);
        IList<Models.JobModel> GetAllJob();
        int AddJobs(JobModel job);
        int UpdateJobestToComplite(decimal? currentquotedhoursUsed, decimal? forecastquoteHours, decimal? estimatetocomplite, decimal? totalforecostHours, decimal? CurrentprecentTroughProject, int jobid);
        int UpdateIslock(int jobid, bool? islock);

        bool? CheckIslock(string UUID);
    }
}