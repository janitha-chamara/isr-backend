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
       

        public TaskController(ITaskService taskService )
        {
           // var pollWmfDataService = new PollWmfDataService();
           // pollWmfDataService.PollWmfData();
            _taskService = taskService;
          //  _clientService = clientService;
        }

        [HttpGet, Route("api/[controller]/TasksByJobId")]
        public BaseResponse<IList<TaskDto>> GetTaskByJobId(int jobId)
        {
            var result = _taskService.GetTaskByJobId(jobId);
            var taskDtoList = result.Response.Select(x => x.ToTaskDto()).ToList();
            return new BaseResponse<IList<TaskDto>>(taskDtoList);

        }

        //public BaseResponse<IList<TaskDto>> UpdateTask(List<TaskDto> tasklist)
        //{
        //    //var result = _taskService.GetTaskByJobId(jobId);
        //    var taskDtoList = result.Response.Select(x => x.ToTaskDto()).ToList();
        //    return new BaseResponse<IList<TaskDto>>(taskDtoList);

        //}
      

    }
}