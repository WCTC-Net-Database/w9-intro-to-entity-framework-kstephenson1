using System.Text.Json;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.FileIO.Json.Converters;

// The JsonInventoryConverter is used to turn json format into an Inventories Object automatically.
public class JsonInventoryConverter : JsonConverter<Inventory>
{
    public override Inventory? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            throw new JsonException("ARRAYREADER: Value is null");
        }
        else if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("ARRAYREADER: Value is not an array.");
        }
        var itemSet = new List<string>();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return InventorySerializer.DeserializeList(itemSet);
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                itemSet.Add(reader.GetString()!);
            }
            else
            {
                throw new JsonException($"ARRAYREADER: Unexpected token type {reader.TokenType}");
            }
        }
        throw new JsonException($"ARRAYREADER: Unexpected token type {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, Inventory inventory, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (string item in InventorySerializer.SerializeList(inventory)!)
        {
            writer.WriteStringValue(item);
        }

        writer.WriteEndArray();
    }
}
