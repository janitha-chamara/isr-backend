using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using ISRDataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Xml;

namespace ISRAPI.Controllers
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IJobService _jobService;



        public TaskController(ITaskService taskService ,IJobService jobService)
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
            decimal? CurrentTroughProject = 0;
            decimal? forecastquoteHours = 0;
            decimal? ah = 0;


            int jobid = 0;

            foreach (var item in tasklist)
            {
                jobid =item.JobId;
                ah += item.ActualHours;
                estimatetocomplite += item.EstToComplHours;
                totalforecostHours += item.TotalForecastHours;
                forecastquoteHours = totalforecostHours / ah;
                CurrentTroughProject = (totalforecostHours - estimatetocomplite) / totalforecostHours;
                var result = _taskService.UpdateTask(item.ToTaskModel());
            }
            var id = _jobService.UpdateEstimatetoComplete(forecastquoteHours, estimatetocomplite, totalforecostHours, CurrentTroughProject, jobid);

            return new BaseResponse<int>(1);

        }

    }
}