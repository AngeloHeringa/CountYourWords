using CountYourWords.Interfaces;

namespace CountYourWords.Services;

public class FileReader(string filePath) : IFileReader
{
    public string? ReadAllText()
    {
        string? rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        if (rootDirectory == null)
            return null;
        var fullPath = Path.Combine(rootDirectory, filePath);
        return File.Exists(fullPath) ? File.ReadAllText(fullPath) : null;
    }
}