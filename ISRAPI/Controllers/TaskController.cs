﻿using BusinessLogic;
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
            decimal? currentquotedhoursUsed = 0;

            decimal? totalforecostHours = 0;
            decimal? CurrentTroughProject = 0;
            decimal? forecastquoteHours = 0;
            decimal? ah = 0;
            decimal? qh = 0;
            int isnullCompleteHours = 0;
            int isActualHoursNull = 0;

            int jobid = 0;
            foreach (var item in tasklist)
            {
                jobid = item.JobId;
                ah += item.ActualHours;
                qh += item.QuotedHours;
                estimatetocomplite += item.EstToComplHours ?? 0;
                totalforecostHours += item.EstToComplHours + item.ActualHours ?? 0;

                if (item.ActualHours != null && item.EstToComplHours == null)
                {
                    isnullCompleteHours += 1;
                }


                if (item.ActualHours == null && estimatetocomplite == null)
                {
                    totalforecostHours += item.QuotedHours;
                }
                if (totalforecostHours != null && totalforecostHours != 0)
                {
                    CurrentTroughProject = ((totalforecostHours - estimatetocomplite) / totalforecostHours) * 100;

                }
                if (ah == 0)
                {
                    forecastquoteHours = null;
                }
                else
                {
                    currentquotedhoursUsed = (ah / qh) * 100;
                    forecastquoteHours = (totalforecostHours / qh ?? 0) * 100;
                }
                var result = _taskService.UpdateTask(item.ToTaskModel());
            }
            var id = _jobService.UpdateEstimatetoComplete(currentquotedhoursUsed,forecastquoteHours, estimatetocomplite, totalforecostHours, CurrentTroughProject, jobid);

            return new BaseResponse<int>(1);

        }

    }
}