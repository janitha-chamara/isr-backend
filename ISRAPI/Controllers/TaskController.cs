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


        public TaskController(ITaskService taskService)
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

        public BaseResponse<int> UpdateTask(List<TaskDto> tasklist)
        {
            foreach (var item in tasklist)
            {
                var result = _taskService.UpdateTask(item.ToTaskModel());
            }
            return new BaseResponse<int>(1);

        }

        [HttpGet, Route("api/[controller]/PollWmfData")]
        public async void PollWmfData()
        {


            var httpClient = new HttpClient();
            var query = new Dictionary<string, string>()
            {
                ["apiKey"] = "14C10292983D48CE86E1AA1FE0F8DDFE",
                ["accountKey"] = "6B251F752F7441F8B76D538557E40109",
                //  ["from"] = "20220130",
                //["To"] = "20220202",
                ["uuidMode"] = "transition"
            };
            var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/tasks", query);
            //var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/list?", query);
            //var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/get/SRA?", query);


            var wmfDataResponse = await httpClient.GetAsync(uri);
            var xml = await wmfDataResponse.Content.ReadAsStringAsync();
            var xmlDocument = new XmlDocument();



            xmlDocument.LoadXml(xml);


            string json = JsonConvert.SerializeXmlNode(xmlDocument);


            JsonSerializerSettings config = new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
            var jsond = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented, config);


            dynamic json2 = JsonConvert.DeserializeObject(jsond);
            XmlTasks foo = JsonConvert.DeserializeObject<XmlTasks>(json2);

            //XmlTasks jobres = JsonConvert.DeserializeObject<XmlTasks>(jsond);

            //XmlTasks xmltask = System.Text.Json.JsonSerializer.Deserialize<XmlTasks>(jsond);

            //XmlTasks xmltask = Newtonsoft.Json.JsonSerializer.Deserialize<XmlTasks>(foo);

            //var job = jobres.Response.Jobs.Job;
            //foreach (var item in job)
            //{
            //    var jobid = _jobService.AddJob(item);
            //    int id = Convert.ToInt32(jobid);
            //    //foreach (var task in item.Tasks.Task)
            //    //{
            //    //    TaskModel taskmodel = task.ToTaskModelFromWFM(id);
            //    //    var taskid = _taskService.AddTask(taskmodel);
            //    //}

            //}





        }
    }
}