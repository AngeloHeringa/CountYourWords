using System.Text;

namespace CountYourWords.Models;

public class MapResult : Dictionary<string, int>
{
    public MapResult() { }
    public MapResult(IDictionary<string, int> dictionary) : base(dictionary) { }

    public override string ToString()
    {
        var sb = new StringBuilder();
        
        // Append sum of all word counts 
        int totalWords = this.Values.Sum();
        sb.AppendLine($"Number of words: {totalWords}\n");

        // Append words with word count
        foreach (KeyValuePair<string, int> entry in this)
        {
            sb.AppendLine($"{entry.Key} {entry.Value}");
        }

        return sb.ToString();
    }
}