using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISRAPI.Controllers
{
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            var pollWmfDataService = new PollWmfDataService();
            pollWmfDataService.PollWmfData();
            _jobService = jobService;
        }

        [HttpGet, Route("api/[controller]/FindJobById")]
        public BaseResponse<JobDto> GetJobById(int id)
        {
            var result = _jobService.GetJobById(id);

            return result.Success
                ? new BaseResponse<JobDto>(result.Response.ToJobDto())
                : new BaseResponse<JobDto>(result.Message, false);
        }

        [HttpGet, Route("api/[controller]/GetAllJobs")]
        public BaseResponse<IList<JobDto>> GetAllJob()
        {
            var allJobs = _jobService.GetAllJob();
            var jobDtoList = allJobs.Response.Select(job => job.ToJobDto()).ToList();

            return new BaseResponse<IList<JobDto>>(jobDtoList);
        }

        [HttpGet, Route("api/[controller]/GetTaskByJobId")]
        public BaseResponse<IList<TaskDto>> GetTaskByJobId( int id)
        {
            var alltask = _jobService.GetTaskByJobId(id);
            var taskDtoList = alltask.Response.Select(task => task.ToTaskDto()).ToList();

            return new BaseResponse<IList<TaskDto>>(taskDtoList);
        }

        [HttpPost, Route("api/[controller]/AddJobs")]
        public BaseResponse<int> AddJobs( JobDto jobDto)
        {
            var result = _jobService.AddJob(jobDto.ToJobModel());

            return result.Success
                ? new BaseResponse<int>(result.Response) 
                : new BaseResponse<int>(result.Message,false);
        }
    }
}