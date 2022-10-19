﻿using BusinessLogic.Model;
using Newtonsoft.Json;

namespace BusinessLogic
{
    public class Response
    {
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "Jobs")]
        public Jobs? Jobs { get; set; }

        [JsonProperty(PropertyName = "CustomFields")]
        public CustomFields? CustomFields { get; set; }

    }
}
