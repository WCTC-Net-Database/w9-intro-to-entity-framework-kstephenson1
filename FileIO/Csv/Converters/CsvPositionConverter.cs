using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using w9_assignment_ksteph.DataTypes.Structs;

namespace w9_assignment_ksteph.FileIO.Csv.Converters;

// The CsvInventoryConverter is used to turn the inventory string into an Inventories Object automatically.
public class CsvPositionConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        string[] parse = text!.Split(',');
        return new Position
            (
                Convert.ToInt32(parse[0]),
                Convert.ToInt32(parse[1])
            );
    }
}
