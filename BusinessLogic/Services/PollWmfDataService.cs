using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using BusinessLogic.Interfaces;
using DataMigrations.DataModels;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace BusinessLogic.Services;

public class PollWmfDataService
{
    private readonly ITaskService _taskService;
    private readonly IClientDal _clientdal;
    //private readonly IClientService _clientService;


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
            ClientModel client = new ClientModel();
            client.ClientId = item.client.Id;
            client.ClientName = item.client.Name;
            var id = _clientdal.SaveClinet(client);

        }




    }




    // var id = _clientService.AddClientfromwfm(Client client);


}