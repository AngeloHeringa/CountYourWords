using CountYourWords.Services;

namespace CountYourWords.Tests;

public class FileReaderTests : IDisposable
{
    // Create a temp file to use in tests
    private readonly string _tempFilePath = Path.GetTempFileName();

    public void Dispose()
    {
        // Clean up temp file after each test
        if (File.Exists(_tempFilePath))
            File.Delete(_tempFilePath);
    }
    
    [Fact]
    public void ReadAllText_ReturnsFileContent_WhenFileExists()
    {
        // Arrange
        var expectedContent = "Hello world!";
        File.WriteAllText(_tempFilePath, expectedContent);
        var fileReader = new FileReader(_tempFilePath);

        // Act
        var result = fileReader.ReadAllText();

        // Assert
        Assert.Equal(expectedContent, result);
    }

    [Fact]
    public void ReadAllText_ReturnsNull_WhenFileDoesNotExist()
    {
        // Arrange
        var nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var fileReader = new FileReader(nonExistentPath);

        // Act
        var result = fileReader.ReadAllText();

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void ReadAllText_RootDirectoryIsNull_ReturnsNull()
    {
        // Arrange
        var fileReader = new FileReader("some/file.txt");

        // Act
        string? result = fileReader.ReadAllText();

        // Assert
        Assert.Null(result);
    }
}