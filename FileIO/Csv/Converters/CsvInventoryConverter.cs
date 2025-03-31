using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.FileIO.Csv.Converters;

// The CsvInventoryConverter is used to turn the inventory string into an Inventories Object automatically.
public class CsvInventoryConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        return InventorySerializer.Deserialize(text!);
    }
}
