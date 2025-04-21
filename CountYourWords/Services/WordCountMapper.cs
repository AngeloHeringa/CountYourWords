using System.Text.RegularExpressions;
using CountYourWords.Interfaces;

namespace CountYourWords.Services;

public class WordCountMapper : IWordCountMapper
{
    public Dictionary<string, int> WordCountMap(string input)
    {
        var wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        if (string.IsNullOrWhiteSpace(input))
            return wordCounts; // Return empty dictionary for invalid inputs

        // Filter out punctuation and number characters using regex
        var matches = Regex.Matches(input, @"\b[a-zA-Z]+\b");

        return Sorter<string>.SortWithComparator(matches
                .Select(match => match.Value.ToLowerInvariant())) // refactor to lowercase for comparison 
            .GroupBy(word => word)
            .ToDictionary(group => group.Key,
                group => group.Count()); // Convert Grouping to Dictionary with occurence count
    }
}