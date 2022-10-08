using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Program
{
    public static void Main()
    {
        string jsonData = @"
            {
              ""data"": [
                {
                  ""ID"": ""5367ab140026875f70677ab277501bfa"",
                  ""name"": ""Happiness Initiatives - Flow of Communication/Process & Efficiency"",
                  ""objCode"": ""PROJ"",
                  ""percentComplete"": 100.0,
                  ""plannedCompletionDate"": ""2014-08-22T17:00:00:000-0400"",
                  ""plannedStartDate"": ""2014-05-05T09:00:00:000-0400"",
                  ""priority"": 1,
                  ""projectedCompletionDate"": ""2014-12-05T08:10:21:555-0500"",
                  ""status"": ""CPL""
                },
                {
                  ""ID"": ""555f452900c8b845238716dd033cf71b"",
                  ""name"": ""UX Personalization Think Tank and Product Strategy"",
                  ""objCode"": ""PROJ"",
                  ""percentComplete"": 0.0,
                  ""plannedCompletionDate"": ""2015-12-01T09:00:00:000-0500"",
                  ""plannedStartDate"": ""2015-05-22T09:00:00:000-0400"",
                  ""priority"": 1,
                  ""projectedCompletionDate"": ""2016-01-04T09:00:00:000-0500"",
                  ""status"": ""APR""
                },
                {
                  ""ID"": ""528b92020051ab208aef09a4740b1fe9"",
                  ""name"": ""SCL Health System - full Sitecore implementation (Task groups with SOW totals in Planned hours - do not bill time here)"",
                  ""objCode"": ""PROJ"",
                  ""percentComplete"": 100.0,
                  ""plannedCompletionDate"": ""2016-04-08T17:00:00:000-0400"",
                  ""plannedStartDate"": ""2013-11-04T09:00:00:000-0500"",
                  ""priority"": 1,
                  ""projectedCompletionDate"": ""2013-12-12T22:30:00:000-0500"",
                  ""status"": ""CPL""
                }
             ]
            }";

        var data = JsonConvert.DeserializeObject<Root>(jsonData).Data;

        foreach (var dict in data)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }
            Console.WriteLine();
        }
    }
}

class Root
{
    public List<Dictionary<string, object>> Data { get; set; }
}
