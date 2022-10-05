using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BusinessLogic
{
    public sealed class NonStrictArrayConverter<T> : JsonConverter<T> where T : IEnumerable
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                // Proper array, we can deserialize from this token onwards.
                return JsonSerializer.Deserialize<T>(ref reader, options);
            }

            var value = default(T);
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    value = JsonSerializer.Deserialize<T>(ref reader, options);
                }
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    // finished processing the array and reached the outer closing bracket token of wrapper object.
                    break;
                }
            }

            return value;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }




    //public class ArrayConverter<T> : System.Text.Json.Serialization.JsonConverter<List<T>>
    //{
    //    public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        // Let's check we are dealing with a proper array format([]) adhering to the JSON spec.
    //        if (reader.TokenType == JsonTokenType.StartArray)
    //        {
    //            // Proper array, we can deserialize from this token onwards.
    //            return System.Text.Json.JsonSerializer.Deserialize<List<T>>(ref reader, options);
    //        }



    //        List<T> list = null;
    //        while (reader.Read())
    //        {
    //            if (reader.TokenType == JsonTokenType.StartArray)
    //            {
    //                list = System.Text.Json.JsonSerializer.Deserialize<List<T>>(ref reader, options);
    //            }
    //            if (reader.TokenType == JsonTokenType.EndObject)
    //            {
    //                // finished processing the array and reached the outer closing bracket token of wrapper object.
    //                break;
    //            }
    //        }

    //        return list;
    //    }

    //    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    //    {
    //        // Nothing special to do in write operation. So use default serialize method.
    //        System.Text.Json.JsonSerializer.Serialize(writer, value, value.GetType(), options);
    //    }

    //}


    //public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    //{
    //    public override DateTimeOffset Read(
    //        ref Utf8JsonReader reader,
    //        Type typeToConvert,
    //        JsonSerializerOptions options)
    //    {
    //       return DateTimeOffset.ParseExact(reader.GetString()!,
    //            "MM/dd/yyyy", CultureInfo.InvariantCulture);
    //    }

    //    public override void Write(
    //        Utf8JsonWriter writer,
    //        DateTimeOffset dateTimeValue,
    //        JsonSerializerOptions options) {
    //            writer.WriteStringValue(dateTimeValue.ToString(
    //                "MM/dd/yyyy", CultureInfo.InvariantCulture));
    //        }
    //}
}
