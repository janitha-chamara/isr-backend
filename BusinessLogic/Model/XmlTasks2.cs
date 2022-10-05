namespace BusinessLogic
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class XmlTasks2
    {
        [JsonProperty(PropertyName = "Response")]
        Response? Response { get; set; }
    }
}
