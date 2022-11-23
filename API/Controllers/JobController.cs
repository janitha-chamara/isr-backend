﻿using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISRAPI.Controllers
{
    [ApiController]
    
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;


        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //[HttpGet, Route("api/[controller]/FindJobById")]
        //public BaseResponse<JobDto> GetJobById(int id)
        //{
        //    var result = _jobService.GetJobById(id);

        //    return result.Success
        //        ? new BaseResponse<JobDto>(result.Response.ToJobDto())
        //        : new BaseResponse<JobDto>(result.Message, false);
        //}

        [HttpGet, Route("api/[controller]/GetAlljobs")]
        public BaseResponse<IList<JobDto>> GetAlljobs()
        {
            var allJobs = _jobService.GetAllJob();
            var jobDtoList = allJobs.Response.Select(job => job.ToJobDto()).ToList();

            return new BaseResponse<IList<JobDto>>(jobDtoList);
        }


    }
}
