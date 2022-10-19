using BusinessLogic.Models;
using ISRDataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IJobService
    {
        ServiceResponse<JobModel> GetJobById(int roleId);
        ServiceResponse<IList<JobModel>> GetAllJob();
        ServiceResponse<int> AddJob(Job item);
        ServiceResponse<int> UpdateHours(decimal? actualHours, decimal? quotedHours, Job job);
        ServiceResponse<int> UpdateEstimatetoComplete(decimal? currentquotedhoursUsed, decimal? forecastquoteHours, decimal? estimatetocomplite, decimal? totalforecostHours, decimal? CurrentprecentTroughProject, int jobid);
    
    }
}