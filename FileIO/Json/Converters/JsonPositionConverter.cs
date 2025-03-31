using System.Text.Json;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.DataTypes.Structs;

namespace w9_assignment_ksteph.FileIO.Json.Converters;

// The JsonPositionConverter is used to turn json format into Positions structs automatically.
public class JsonPositionConverter : JsonConverter<Position>
{
    List<int> coords = new();
    public override Position Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            throw new JsonException("JsonPositionConverter: Value is null");
        }
        else if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("JsonPositionConverter: Start of object reached.");
        }
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                Position result = new(coords[0], coords[1]);
                coords = new();
                return result;
            }
            else if (reader.TokenType == JsonTokenType.PropertyName)
            {
                //
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                coords.Add(reader.GetInt32());
            }
            else
            {
                throw new JsonException($"JsonPositionConverter: Unexpected token type {reader.TokenType}");
            }
        }
        throw new JsonException($"JsonPositionConverter: Unexpected token type {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, Position position, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("x");
        writer.WriteNumberValue(position.x);
        writer.WritePropertyName("z");
        writer.WriteNumberValue(position.z);
        writer.WriteEndObject();
    }
}
