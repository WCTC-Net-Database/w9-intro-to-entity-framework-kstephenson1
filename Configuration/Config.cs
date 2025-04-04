using w9_assignment_ksteph.DataTypes;

namespace w9_assignment_ksteph.Configuration;

public static class Config
{
    // Added this config file to add changable aspects of the program.  Could (and probably should) be changed to a .config file at a later date.

    /* * * * * * * * * * * * * * * * *
     *       CHARACTER SETTINGS      *
     * * * * * * * * * * * * * * * * */

    // Sets the maximum level for characters. (Default: 20)
    public const int CHARACTER_LEVEL_MAX = 20;

    /* * * * * * * * * * * * * * * * *
     *         FILE SETTINGS         *
     * * * * * * * * * * * * * * * * */

    // Sets the default file type for reading and writing characters. Options: FileType.Json, FileType.Csv (Default: FileType.Json.)
    [Obsolete]  // Obsolete with the addition of using databases instead of json and csv.
    public const FileType DEFAULT_FILE_TYPE = FileType.Json;

    /* * * * * * * * * * * * * * * * *
    *         CSV SETTINGS          *
    * * * * * * * * * * * * * * * * */

    // If true, the program will add double quotes on all values when writing .csv files.(Default: true)
    [Obsolete]  // Obsolete with the addition of using databases instead of json and csv.
    public const bool CSV_CHARACTER_WRITER_QUOTES_ON_EXPORT = true;
}
