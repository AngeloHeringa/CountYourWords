using CountYourWords.Models;

namespace CountYourWords.Tests;

public class MapResultTests
{
    [Fact]
    public void ToString_ShouldReturnFormattedOutputWithTotalWordCount()
    {
        // Arrange
        var data = new Dictionary<string, int>
        {
            { "apple", 2 },
            { "banana", 3 },
            { "cherry", 1 }
        };
        var mapResult = new MapResult(data);

        // Act
        var result = mapResult.ToString();

        // Assert
        Assert.Contains("Number of words: 6", result);
        Assert.Contains("apple 2", result);
        Assert.Contains("banana 3", result);
        Assert.Contains("cherry 1", result);
    }

    [Fact]
    public void ToString_ShouldHandleEmptyMapResult()
    {
        // Arrange
        var mapResult = new MapResult();

        // Act
        var result = mapResult.ToString();

        // Assert
        Assert.Contains("Number of words: 0", result);
    }
}