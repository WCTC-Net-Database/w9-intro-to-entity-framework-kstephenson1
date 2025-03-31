namespace w9_assignment_ksteph.Models.Interfaces.FileIO;

public interface IFileIO
{
    List<T> Read<T>(string dir);
    void Write<T>(List<T> t, string dir);
}
