using System.Xml;
using System.Xml.Linq;
using ISRDataAccess.Models;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Services;

public class PollWmfDataService
{
    public async void PollWmfData()
    {
        var httpClient = new HttpClient();

        var query = new Dictionary<string, string>()
        {
            ["apiKey"] = "14C10292983D48CE86E1AA1FE0F8DDFE",
            ["accountKey"] = "6B251F752F7441F8B76D538557E40109",
            ["from"] = "20220110",
            ["to"] = "20220202",
            ["UUIDMode"] = "transition"
        };

        var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/list?", query);

        var wmfDataResponse = await httpClient
            .GetAsync(uri);

        var xml = await wmfDataResponse.Content.ReadAsStringAsync();

        // var doc = XDocument.Parse(xml);

        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xml);

        string json = JsonConvert.SerializeXmlNode(xmlDocument);

        var jo = JObject.Parse(json);


        var list = new List<JobModel>();

        foreach (var prop in jo.Properties())
        {
            foreach (var item in prop)
            {
                foreach (var item1 in item)
                {
                    var value = item1;
                    var data = new JobModel
                    {
                        UUID = value["UUID"].ToString(),
                        JobName = value["Name"].ToString(),
                        JobNo = value["ID"].ToString(),
                        Description = value["Description"].ToString(),

                    };
                    list.Add(data);
                }

            }


        }


        Console.WriteLine(jo["Response"]?["Jobs"]);
    }

    // public saveWmfData()
    // {
    // }
}