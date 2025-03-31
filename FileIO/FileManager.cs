namespace w9_assignment_ksteph.FileIO;

using w9_assignment_ksteph.Configuration;
using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.FileIO.Csv;
using w9_assignment_ksteph.FileIO.Json;
using w9_assignment_ksteph.Models.Interfaces.FileIO;
using w9_assignment_ksteph.Models.Items.WeaponItems;
using w9_assignment_ksteph.Models.Units.Abstracts;

public class FileManager<T>
{
    // FileManager contains redirects to functions that assist with file IO functions.  This class allows the import and export of a generic
    // unit type.

    private FileType _fileType = Config.DEFAULT_FILE_TYPE;

    private Type _type = typeof(T);
    private Dictionary<Type, int> _typeDict = new()
    {
            {typeof(UnitBase),0},
            {typeof(CharacterBase),1},
            {typeof(MonsterBase),2},
            {typeof(WeaponItem),3},
        };

    private string GetFilePath()
    {
        return _typeDict[_type] switch
        {
            0 => "Data/Files/units",
            //1 => "Files/characters",
            //2 => "Files/monsters",
            3 => "Data/Files/weapons",
            _ => throw new ArgumentOutOfRangeException($"GetFilePath() has invalid type ({_typeDict})")
        };

    }

    private IFileIO GetFileType<T>() // Checks to see what the current file type is set to and execute the proper file system.
    {
        return _fileType switch
        {
            FileType.Csv => new CsvFileHandler<T>(),
            FileType.Json => new JsonFileHandler<T>(),
            _ => throw new NullReferenceException("Error: File type not found in FileManager.GetFileType()"),
        };
    }

    public void SwitchFileType()
    {
        Console.Clear();
        if (_fileType == FileType.Csv)
        {
            Console.WriteLine("File format set to Json.");
            _fileType = FileType.Json;
        } else
        {
            Console.WriteLine("File format set to Csv.");
            _fileType = FileType.Csv;
        }
    }

    public List<T> Import<T>() => GetFileType<T>().Read<T>(GetFilePath());
    public void Export<T>(List<T> tList) => GetFileType<T>().Write<T>(tList, GetFilePath());
}
