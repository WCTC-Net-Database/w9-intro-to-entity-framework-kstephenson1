namespace w9_assignment_ksteph.FileIO.Json;

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.FileIO.Json.Converters;
using w9_assignment_ksteph.Models.Interfaces.FileIO;

public class JsonFileHandler<T> : ICharacterIO, IItemIO
{
    // JsonFileHandler is used to convert bewtween units and json format.  Just like the CsvFileHandler, this class was refactored
    // to implement generic types.

    private const string JSON_EXT = ".json";
    private readonly JsonSerializerOptions _options = new();

    public JsonFileHandler()
    {
        _options.Converters.Add(new JsonInventoryConverter());      // Using a custom converter to convert json string -> Inventory
        _options.Converters.Add(new JsonUnitConverter());      // Using a custom converter to convert json string -> Inventory

        _options.Converters.Add(new JsonNumberEnumConverter<WeaponType>());       // Using a custom converter to convert json string -> Position
        _options.Converters.Add(new JsonStringEnumConverter());       // Using a custom converter to convert json string -> Position
        _options.WriteIndented = true;                              // Writes the json file in indented format.
        //_options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }

    public List<T> Read<T>(string dir)
    {

        using StreamReader reader = new(dir + JSON_EXT);            // reads from the json file and returns a list of characters.
        string json = reader.ReadToEnd();

        return JsonSerializer.Deserialize<List<T>>(json, _options)!;
    }

    public void Write<T>(List<T> units, string dir)
    {
        using StreamWriter writer = new(dir + JSON_EXT);            // Takes a list of characters and writes to the json file
        writer.WriteLine(JsonSerializer.Serialize<List<T>>(units, _options));
    }
}
