using CountYourWords.Interfaces;

namespace CountYourWords.Services;

public class FileReader(string filePath) : IFileReader
{
    public string? ReadAllText()
    {
        return File.Exists(filePath) ? File.ReadAllText(filePath) : null;
    }
}