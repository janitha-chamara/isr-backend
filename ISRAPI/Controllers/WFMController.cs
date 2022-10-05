using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Xml;

namespace ISRAPI.Controllers
{
    [ApiController]
    public class WFMController : ControllerBase
    {
         private readonly IJobService _jobService;
        private readonly ITaskService _taskService;
       

        public WFMController( IJobService jobService, ITaskService taskService)
        {
   
            _taskService = taskService;
            _jobService = jobService;
    
        }

        [HttpGet, Route("api/[controller]/PollWmfData")]
        public async void PollWmfData()
        {
            var httpClient = new HttpClient();
            var query = new Dictionary<string, string>()
            {
                ["apiKey"] = "14C10292983D48CE86E1AA1FE0F8DDFE",
                ["accountKey"] = "6B251F752F7441F8B76D538557E40109",
                ["from"] = "20220130",
                ["To"] = "20220202",
                ["uuidMode"] = "transition"
            };
            //var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/tasks", query);
            var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/list?", query);
            //var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/get/LEA005541?", query);

            var wmfDataResponse = await httpClient.GetAsync(uri);
            var xml = await wmfDataResponse.Content.ReadAsStringAsync();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            string json = JsonConvert.SerializeXmlNode(xmlDocument);
            var _options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
            };

            XmlTasks jobres = JsonConvert.DeserializeObject<XmlTasks>(json);
            var job = jobres.Response.Jobs.Job;
            foreach (var item in job)
            {
                var jobid = _jobService.AddJob(item);
            }





        }
    }
}
