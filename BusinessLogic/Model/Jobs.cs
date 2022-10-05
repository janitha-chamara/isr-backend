using Newtonsoft.Json;

namespace BusinessLogic
{
    public class Jobs
    {
        [JsonProperty(PropertyName = "Job")]
        public List<Job> Job { get; set; }
    }
}
