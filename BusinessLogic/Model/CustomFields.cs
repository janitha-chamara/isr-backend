using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class CustomFields
    {
        [JsonProperty(PropertyName = "CustomField")]
        public CustomField[] customField { get; set; }
    }



    public class CustomField
    {
        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "UUID")]
        public string? UUID { get; set; }
     
        [JsonProperty(PropertyName = "Name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "Boolean")]
        public bool? IsISR { get; set; }
    }


}
