using CountYourWords.Services;

namespace CountYourWords.Tests;

public class WordCountMapperTests
{
    private readonly WordCountMapper _mapper = new();

    [Fact]
    public void WordCountMap_ReturnsCorrectCounts_ForNormalText()
    {
        // Arrange
        var input = "Hello world! Hello, HELLO. This is a test. Test test.";

        // Act
        var result = _mapper.WordCountMap(input);

        // Assert
        Assert.Equal(3, result["hello"]);
        Assert.Equal(1, result["world"]);
        Assert.Equal(1, result["this"]);
        Assert.Equal(1, result["is"]);
        Assert.Equal(1, result["a"]);
        Assert.Equal(3, result["test"]);
    }

    [Fact]
    public void WordCountMap_ReturnsEmptyDictionary_ForEmptyString()
    {
        // Arrange
        var input = "";

        // Act
        var result = _mapper.WordCountMap(input);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void WordCountMap_IsCaseInsensitive()
    {
        // Arrange
        var input = "Case case CASE CaSe";

        // Act
        var result = _mapper.WordCountMap(input);

        // Assert
        Assert.Single(result);
        Assert.Equal(4, result["case"]);
    }
    
    [Fact]
    public void WordCountMap_IgnoresNumbersAndAlphanumericWords()
    {
        // Arrange
        var input = "123 4567 abc123 test TEST test1 42 is ok";

        // Act
        var result = _mapper.WordCountMap(input);

        // Assert
        Assert.DoesNotContain("123", result.Keys);
        Assert.DoesNotContain("4567", result.Keys);
        Assert.DoesNotContain("abc123", result.Keys);
        Assert.DoesNotContain("test1", result.Keys);
        Assert.DoesNotContain("42", result.Keys);

        Assert.Contains("test", result.Keys);
        Assert.Equal(2, result["test"]); // "test" and "TEST"
        Assert.Contains("is", result.Keys);
        Assert.Contains("ok", result.Keys);
    }

}