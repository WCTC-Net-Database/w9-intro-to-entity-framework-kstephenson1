using CsvHelper.Configuration;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.FileIO.Csv.Converters;

[Obsolete]
public class UnitMap : ClassMap<Unit>
{
    // The UnitMap assists the turning the csv file into units.
    // This class allows the inventory to be imported as a custom Inventories object instead of a string with
    // the help of the InventoryConverter
    [Obsolete]
    public UnitMap()
    {
        Map(unit => unit.Name);
        Map(unit => unit.Class);
        Map(unit => unit.Level);
        Map(unit => unit.Inventory).TypeConverter(new CsvInventoryConverter());
    }
}
