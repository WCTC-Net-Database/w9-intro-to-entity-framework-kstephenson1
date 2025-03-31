using System.Text.Json;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Inventories;

namespace w9_assignment_ksteph.FileIO.Json.Converters;

public class JsonInventoryValueConverter : JsonConverterFactory
{
    public override bool CanConvert(Type type)
    {
        // Determines whether or not this converter can interact with the type.
        if (type == typeof(Inventory))
            return true;
        else
            return false;
    }

    public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
    {
        // Seems to pull a new default Inventory object from thin air cast as a JsonConverter.
        // I do not fully understand how this is useful but it's there for a reason and I do not dare touch it!
        // credit: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to
        return (JsonConverter)Activator.CreateInstance(typeof(Inventory).MakeGenericType())!;
    }
}
