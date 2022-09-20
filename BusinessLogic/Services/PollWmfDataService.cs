using System.Xml;
using System.Xml.Linq;
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
            ["Complite"] = "False"
        };

        var uri = QueryHelpers.AddQueryString("https://api.workflowmax.com/job.api/tasks", query);
        
        var wmfDataResponse = await httpClient
            .GetAsync(uri);

        var xml = await wmfDataResponse.Content.ReadAsStringAsync();

        // var doc = XDocument.Parse(xml);
        
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xml);
        
        string json = JsonConvert.SerializeXmlNode(xmlDocument);
        
        var jo = JObject.Parse(json);

        Console.WriteLine(jo["Response"]?["Jobs"]);
    }

    // public saveWmfData()
    // {
    // }
}