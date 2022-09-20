using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        // [HttpGet, Route("{GetJobById}")]
        // public BaseResponse<JobDto> GetJobById(int id)
        // {
        //     var result = _jobService.GetJobById(id);
        //
        //     return result.Success
        //         ? new BaseResponse<JobDto>(result.Response.ToJobDto())
        //         : new BaseResponse<JobDto>(result.Message, false);
        // }

        [HttpGet, Route("{GetAllJob}")]
        public BaseResponse<IList<JobDto>> GetAllJob()
        {
            var result = _jobService.GetAllJob();
            var response =  result.Response.Select(x => x.ToJobDto()).ToList();

            return new BaseResponse<IList<JobDto>>(response);
        }
    }
}
