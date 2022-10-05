using Newtonsoft.Json;

namespace BusinessLogic
{
    public class Client
    {
        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "UUID")]
        public string UUID { get; set; }


    }
}
