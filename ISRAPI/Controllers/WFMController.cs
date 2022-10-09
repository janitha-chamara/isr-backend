using BusinessLogic;
using BusinessLogic.Interfaces;
using ISRDataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Nancy.Json;
using Newtonsoft.Json;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace ISRAPI.Controllers
{
    [ApiController]
    public class WFMController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ITaskService _taskService;
        public WFMController(IJobService jobService, ITaskService taskService)
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
                ["uuidMode"] = "transition"
            };
            var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/tasks", query);
            var wmfDataResponse = await httpClient.GetAsync(uri);
            var xml = await wmfDataResponse.Content.ReadAsStringAsync();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(xmlDocument);
            XmlTasks jobres = JsonConvert.DeserializeObject<XmlTasks>(json);
            var job = jobres.Response.Jobs.Job;
            foreach (var item in job)
            {
                var jobid = _jobService.AddJob(item);
                var temptask = item.Tasks.Task;
                var tasks = new List<SingleTask>();
                if (temptask.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                {
                    SingleTask[] temptask1 = JsonConvert.DeserializeObject<SingleTask[]>(item.Tasks.Task.ToString());
                    tasks.AddRange(temptask1);
                }
                else
                {
                    SingleTask temptask1 = JsonConvert.DeserializeObject<SingleTask>(item.Tasks.Task.ToString());
                    tasks.Add(temptask1);
                }
                decimal actualHours = 0;
                decimal QuoteHours = 0;
                foreach (var task in tasks)
                {
                    actualHours += Convert.ToDecimal(task.ActualMinutes) ;
                    QuoteHours += Convert.ToDecimal(task.EstimatedMinutes);

                    TaskModel taskmodel = task.ToTaskModelFromWFM(jobid.Response);
                    var taskid = _taskService.UpdateTaskFromWFM(taskmodel);
                }
                var jobnewid = _jobService.UpdateHours(actualHours, QuoteHours, item.UUID);

            }
        }


    }
}
