using Newtonsoft.Json;
namespace BusinessLogic
{
    public class Tasks
    {
        [JsonProperty(PropertyName = "Task")]
        public object Task { get; set; }

    }
}
