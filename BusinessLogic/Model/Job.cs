using Newtonsoft.Json;

namespace BusinessLogic
{
    public class Job
    {
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "UUID")]
        public string UUID { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string? Name { get; set; }

        //[JsonProperty(PropertyName = "Description")]
        //public string Description { get; set; }

        public Client? client { get; set; }

        //[JsonProperty(PropertyName = "ClientOrderNumber")]
        //public string ClientOrderNumber { get; set; }

        //[JsonProperty(PropertyName = "Budget")]
        //public string Budget { get; set; }

        [JsonProperty(PropertyName = "State")]
        public string State { get; set; }

        //[JsonProperty(PropertyName = "Type")]
        //public string Type { get; set; }

        [JsonProperty(PropertyName = "StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "DueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty(PropertyName = "Contact")]
        public Contact? contact { get; set; }

        //[JsonProperty(PropertyName = "InternalID")]
        //public string InternalID { get; set; }

        [JsonProperty(PropertyName = "Manager")]
        public Manager? manager { get; set; }

        [JsonProperty(PropertyName = "Partner")]
        public Partner? partner { get; set; }

        //[JsonProperty(PropertyName = "Assigned")]
        //public Assigned Assigned { get; set; }

        [JsonProperty(PropertyName = "Tasks")]
        public Tasks Tasks { get; set; }

      
    }
}
