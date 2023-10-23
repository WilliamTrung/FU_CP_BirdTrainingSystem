using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace SP_Middleware.CustomJsonConverter
{

    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string timeString = reader.GetString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
            var time = TimeOnly.Parse(timeString);
#pragma warning restore CS8604 // Possible null reference argument.
            return TimeOnly.Parse(timeString);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

}
