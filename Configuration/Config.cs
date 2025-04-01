using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.DataTypes;

namespace w9_assignment_ksteph.Configuration;

public static class Config
{
    // Added this config file to add changable aspects of the program.  Could (and probably should) be changed to a .config file at a later date.

    /* * * * * * * * * * * * * * * * *
     *        SERVER SETTINGS        *
     * * * * * * * * * * * * * * * * */

    // The data source for the SQL server.
    public const string SQL_SERVER_ADDRESS = "bitsql.wctc.edu";

    // The name of the database in the SQL server listed above.
    public const string SQL_DATABASE_NAME = "kstephenson1_20023_ConsoleGame";

    // SQL Database username.
    public const string SQL_DATABASE_USERNAME = "kstephenson1";

    // SQL Database password with really poor "encryption" if you even want to call it that.
    public const int SQL_DATABASE_PASSWORD_ENCRYPTED = 1802596849;

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
