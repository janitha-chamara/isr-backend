using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Xml;

namespace ISRAPI.Controllers
{
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;


        public JobController(IJobService jobService)
        {
           // var pollWmfDataService = new PollWmfDataService();
           // pollWmfDataService.PollWmfData();
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
                // ["uuidMode"] = "transition"
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
              //  var id = _clientService.AddClient(client);

            }




        }
    }
}
