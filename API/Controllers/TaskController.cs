using BusinessLogic.Interfaces;
using ISRDataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISRAPI.Controllers
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IJobService _jobService;



        public TaskController(ITaskService taskService, IJobService jobService)
        {
            _taskService = taskService;
            _jobService = jobService;
        }

        [HttpGet, Route("api/[controller]/TasksByJobId")]
        public BaseResponse<IList<TaskDto>> GetTaskByJobId(int jobId)
        {
            var result = _taskService.GetTaskByJobId(jobId);
            var taskDtoList = result.Response.Select(x => x.ToTaskDto()).ToList();
            return new BaseResponse<IList<TaskDto>>(taskDtoList);

        }

        [HttpPost, Route("api/[controller]/UpdateTask")]
        public BaseResponse<int> UpdateTask(IList<TaskDto> tasklist)
        {
            decimal? estimatetocomplite = 0;
            decimal? totalforecostHours = 0;
            decimal? CurrentTroughProject=0;
            decimal? ah = 0;
            decimal? qh = 0;
            decimal? achoursNull = 0;
           
            int jobid = 0;
            foreach (var item in tasklist)
            {
                if (item.ActualHours==null && item.EstToComplHours ==null)
                {
                    achoursNull+= item.QuotedHours;
                }
                jobid = item.JobId;
                ah += item.ActualHours ?? 0;
                qh += item.QuotedHours ?? 0;


                estimatetocomplite += item.EstToComplHours ?? 0;
                totalforecostHours += item.TotalForecastHours ?? 0;
                if (item.ActualHours == null && item.EstToComplHours == null|| item.ActualHours == null && item.EstToComplHours == 0)
                {
                    item.TotalForecastHours = item.QuotedHours;
                    item.EstToComplHours = null;
                }
               
                var result = _taskService.UpdateTask(item.ToTaskModel());
            }
            decimal? currentquotedhoursUsed = ah / qh * 100;
            decimal? forecastquoteHours = (totalforecostHours / qh ?? 0) * 100;

            estimatetocomplite = achoursNull + estimatetocomplite;

            if (totalforecostHours!=0)
            {
                CurrentTroughProject= (totalforecostHours - estimatetocomplite) / totalforecostHours * 100;

            }
            //if (CurrentTroughProject==100)
            //{
            //    CurrentTroughProject = null;
            //}
          
            var id = _jobService.UpdateEstimatetoComplete(currentquotedhoursUsed, forecastquoteHours, estimatetocomplite, totalforecostHours, CurrentTroughProject, jobid);
            return new BaseResponse<int>(1);

        }

        //  public BaseResponse<int> UpdateTaskTemp(IList<TaskDto> tasklist)
        //{
        //    decimal? estimatetocomplite = 0;
        //    decimal? currentquotedhoursUsed = 0;
        //    decimal? totalforecostHours = 0;
        //    decimal? CurrentTroughProject = 0;
        //    decimal? forecastquoteHours = 0;
        //    decimal? ah = 0;
        //    decimal? qh = 0;
        //    int isnullCompleteHours = 0;
        //    int jobid = 0;
        //    foreach (var item in tasklist)
        //    {
        //        jobid = item.JobId;
        //        ah += item.ActualHours ?? 0;
        //        qh += item.QuotedHours ?? 0;
        //        estimatetocomplite += item.EstToComplHours ?? 0;
        //        totalforecostHours += item.TotalForecastHours ?? 0;


        //        //if (item.ActualHours != null && item.EstToComplHours == null)
        //        //{
        //        //    isnullCompleteHours += 1;
        //        //}
        //        //if (totalforecostHours != null || totalforecostHours != 0)
        //        //{
        //        //    if (estimatetocomplite == 0)
        //        //    {
        //        //        estimatetocomplite = null;
        //        //        CurrentTroughProject = (totalforecostHours - estimatetocomplite) / totalforecostHours * 100;

        //        //    }
        //        //    else
        //        //    {
        //        //        CurrentTroughProject = (totalforecostHours - estimatetocomplite) / totalforecostHours * 100;

        //        //    }
        //        //}

        //        if (item.ActualHours == null && item.EstToComplHours == null && item.EstToComplHours == null || item.ActualHours == null && item.EstToComplHours == 0)
        //        {
        //            item.TotalForecastHours = item.QuotedHours;
        //            item.EstToComplHours = null;
        //        }
        //        //if (estimatetocomplite == 0)
        //        //{
        //        //    estimatetocomplite = null;
        //        //}

        //        currentquotedhoursUsed = (ah / qh) * 100;
        //        forecastquoteHours = (totalforecostHours / qh ?? 0) * 100;

        //        var result = _taskService.UpdateTask(item.ToTaskModel());
        //    }

        //    CurrentTroughProject = (totalforecostHours - estimatetocomplite) / totalforecostHours * 100;

        //    var id = _jobService.UpdateEstimatetoComplete(currentquotedhoursUsed, forecastquoteHours, estimatetocomplite, totalforecostHours, CurrentTroughProject, jobid);

        //    return new BaseResponse<int>(1);

        //}

    }
}