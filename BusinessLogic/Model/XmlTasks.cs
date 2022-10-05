namespace BusinessLogic
{
    using Newtonsoft.Json;

   // [JsonObject(MemberSerialization = MemberSerialization.Fields)]
    public class XmlTasks
    {
        [JsonProperty(PropertyName = "Response")]
       public Response? Response { get; set; }
    }
}
