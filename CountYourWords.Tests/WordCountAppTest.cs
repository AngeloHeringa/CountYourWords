using CountYourWords.Core;

namespace CountYourWords.Tests;

public class WordCountAppTest
{
    [Fact]
    public void Run_ShouldReturnWordCountResult_WhenFileIsValid()
    {
        // Arrange
        string tempFilePath = Path.GetTempFileName();
        File.WriteAllText(tempFilePath, "apple banana apple");

        var app = new WordCountApp(tempFilePath);

        // Act
        string result = app.Run();

        // Assert
        Assert.Contains("Number of words: 3", result);
        Assert.Contains("apple 2", result);
        Assert.Contains("banana 1", result);

        // Clean up
        File.Delete(tempFilePath);
    }

    [Fact]
    public void Run_ShouldReturnErrorMessage_WhenFileIsEmpty()
    {
        // Arrange
        string tempFilePath = Path.GetTempFileName();
        File.WriteAllText(tempFilePath, "");

        var app = new WordCountApp(tempFilePath);

        // Act
        string result = app.Run();

        // Assert
        Assert.Equal("Error: File is empty.", result);

        // Clean up
        File.Delete(tempFilePath);
    }

    [Fact]
    public void Run_ShouldReturnErrorMessage_WhenFileDoesNotExist()
    {
        // Arrange
        string fakeFilePath = Path.Combine(Path.GetTempPath(), "nonexistent_file.txt");

        var app = new WordCountApp(fakeFilePath);

        // Act
        string result = app.Run();

        // Assert
        Assert.Equal("Error: File not found.", result);
    }
}