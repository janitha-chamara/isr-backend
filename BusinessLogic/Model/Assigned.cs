

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BusinessLogic
{
    public sealed class Assigned
    {
        [JsonProperty(PropertyName = "Staff")]
        //[JsonConverter(typeof(SingleOrArrayConverter<string>))]
        //[JsonConverter(typeof(NonStrictArrayConverter<Staff[]>))]

        public Staff[] Staff { get; set; }

        
    }
}
