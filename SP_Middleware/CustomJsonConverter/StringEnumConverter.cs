using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SP_Middleware.CustomJsonConverter
{
    public class StringEnumConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string enumValueString = reader.GetString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (Enum.TryParse(enumValueString, true, out TEnum enumValue))
            {
                return enumValue;
            }

            throw new JsonException($"Unable to parse enum value: {enumValueString}");
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
