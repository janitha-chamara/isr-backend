using Newtonsoft.Json;
namespace BusinessLogic
{
    public class Tasks
    {
        [JsonProperty(PropertyName = "Task")]
        public Task[] Task { get; set; }

    }
}
