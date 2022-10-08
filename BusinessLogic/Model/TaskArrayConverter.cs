using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public sealed class TaskArrayConverter : JsonConverter<Task[]>
    {
        public override Task[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Let's check we are dealing with a proper array format([]) adhering to the JSON spec.
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                // Proper array, we can deserialize from this token onwards.
                return JsonSerializer.Deserialize < Task[] > (ref reader, options);
            }



           Task[]  list = null;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    list = JsonSerializer.Deserialize<Task[]>(ref reader, options);
                }
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    // finished processing the array and reached the outer closing bracket token of wrapper object.
                    break;
                }
            }

            return list;
        }

        public override void Write(Utf8JsonWriter writer, Task[] value, JsonSerializerOptions options)
        {
            // Nothing special to do in write operation. So use default serialize method.
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
