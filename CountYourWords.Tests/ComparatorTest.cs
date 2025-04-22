using CountYourWords.Services;
namespace CountYourWords.Tests;

public class ComparatorTest
{
    [Fact]
    public void ComparatorFactory_Throws_NotSupportedException()
    {
        Assert.Throws<NotSupportedException>(() => ComparatorFactory.Create<long>());
    }

    [Fact]
    public void RecurringCompare_returns_minusOne_for_shorter_length()
    {
        // Arrange
        string word1 = "aard";
        string word2 = "aardappel";
        
        // Act
        int? result = ComparatorFactory.Create<string>().Compare(word1, word2);
        
        // Assert
        Assert.Equal(-1, result);
    }
    
    [Fact]
    public void RecurringCompare_returns_one_for_longer_length()
    {
        // Arrange
        string word1 = "aardappel";
        string word2 = "aard";
        
        // Act
        int? result = ComparatorFactory.Create<string>().Compare(word1, word2);
        
        // Assert
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void RecurringCompare_returns_null_for_invalid_characters()
    {
        // Arrange
        string word1 = "x(z";
        string word2 = "x)z";
        
        // Act
        int? result = ComparatorFactory.Create<string>().Compare(word1, word2);
        
        // Assert
        Assert.Null(result);
    }
    
}