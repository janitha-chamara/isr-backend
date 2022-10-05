using Newtonsoft.Json;

namespace BusinessLogic
{
    public class Partner
    {
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "UUID")]
        public string UUID { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public string? Type { get; set; }
    }
}
