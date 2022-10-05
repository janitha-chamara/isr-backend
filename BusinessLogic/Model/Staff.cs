using Newtonsoft.Json;

namespace BusinessLogic
{
    
    public sealed class Staff
    {
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "UUID")]
        public string UUID { get; set; }
    }
}
