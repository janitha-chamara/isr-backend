using Newtonsoft.Json;

namespace BusinessLogic
{
    public class Task
    {
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "UUID")]
        public string UUID { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "TaskID")]
        public string TaskID { get; set; }

        [JsonProperty(PropertyName = "EstimatedMinutes")]
        public string EstimatedMinutes { get; set; }

        [JsonProperty(PropertyName = "ActualMinutes")]
        public string ActualMinutes { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Completed")]
        public string Completed { get; set; }

        [JsonProperty(PropertyName = "Billable")]
        public string Billable { get; set; }

        [JsonProperty(PropertyName = "Folder")]
        public string Folder { get; set; }

    }

}
