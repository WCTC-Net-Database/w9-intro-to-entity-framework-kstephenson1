namespace w9_assignment_ksteph.FileIO.Csv;

using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using w9_assignment_ksteph.Configuration;
using w9_assignment_ksteph.Models.Interfaces.FileIO;

[Obsolete]
public class CsvFileHandler<T> : ICharacterIO, IItemIO
{
    // CsvFileHandler<Ttype> is a class that handles the read and write functions for a Ttype type.  This class was turned generic to allow
    // the import and export of Characters, Monsters, and whatever other units we want.

    [Obsolete]
    private const string CSV_EXT = ".csv";

    // Is used to deserialize generic unit types from csv
    [Obsolete]
    public List<T> Read<T>(string dir)
    {
        using StreamReader reader = new(dir + CSV_EXT);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
        //csv.Context.RegisterClassMap<UnitMap>();

        IEnumerable<T> tList = csv.GetRecords<T>();

        return tList.ToList();
    }

    // Is used to serialize generic unit types to csv
    [Obsolete]
    public void Write<T>(List<T> tList, string dir)
    {
        // Checks the Config to determine whether or not to add double quotes to the csv writer output.
        CsvConfiguration config;
        if (Config.CSV_CHARACTER_WRITER_QUOTES_ON_EXPORT)
        {
            config = new CsvConfiguration(CultureInfo.InvariantCulture) { ShouldQuote = args => true };
        }
        else
        {
            config = new CsvConfiguration(CultureInfo.InvariantCulture);
        }

        using StreamWriter writer = new(dir + CSV_EXT);
        using CsvWriter csvOut = new(writer, config);
        //csvOut.Context.RegisterClassMap<UnitMap>();

        csvOut.WriteRecords(tList);
    }

}
