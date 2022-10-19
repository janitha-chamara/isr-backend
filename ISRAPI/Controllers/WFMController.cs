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
            var query = new Dictionary<string, string>()
            {
                ["apiKey"] = "14C10292983D48CE86E1AA1FE0F8DDFE",
                ["accountKey"] = "6B251F752F7441F8B76D538557E40109",
                ["uuidMode"] = "transition"
            };
            var jobTask = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/tasks", query);
            string isISRJson = await CallHttpRequest(jobTask);
            XmlTasks JobResponse = JsonConvert.DeserializeObject<XmlTasks>(isISRJson);
            var job = JobResponse.Response.Jobs.Job;

            foreach (var item in job)
            {
                var isISR = CheckIsISRControl(item.Id);

                if (isISR.Result == true)
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
                        try
                        {
                            if (task.UUID!= null)
                            {
                                actualHours += Convert.ToDecimal(task.ActualMinutes) / 60;
                                QuoteHours += Convert.ToDecimal(task.EstimatedMinutes) / 60;

                                TaskModel taskmodel = task.ToTaskModelFromWFM(jobid.Response);
                                var taskid = _taskService.UpdateTaskFromWFM(taskmodel);
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex.InnerException;
                        }

                    }
                    var jobnewid = _jobService.UpdateHours(actualHours, QuoteHours, item);

                }


            }
        }

        private static async Task<string> CallHttpRequest(string uri)
        {
            var httpClient = new HttpClient();
            var wmfDataResponse = await httpClient.GetAsync(uri);
            var xml = await wmfDataResponse.Content.ReadAsStringAsync();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(xmlDocument);
            return json;
        }

        private static async Task<bool> CheckIsISRControl(string jobId)
        {
            var query = new Dictionary<string, string>()
            {
                ["apiKey"] = "14C10292983D48CE86E1AA1FE0F8DDFE",
                ["accountKey"] = "6B251F752F7441F8B76D538557E40109",
                ["uuidMode"] = "transition"
            };
            string urlcheckISR = "https://api.workflowmax.com/job.api/get/" + jobId + "/customfield?";
            var ckeckisISR = QueryHelpers.AddQueryString(urlcheckISR, query);
            string isISRJson = await CallHttpRequest(ckeckisISR);
            XmlTasks jobres = JsonConvert.DeserializeObject<XmlTasks>(isISRJson);
            var customfield = jobres.Response.CustomFields.customField;

            bool isISR = true;
            foreach (var item in customfield)
            {
                if (item.Name == "Manage via ISR")
                {
                    isISR = item.IsISR.Value;

                }
            }
            return isISR;
        }
    }
}
