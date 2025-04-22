// Core/WordCountApp.cs
using CountYourWords.Services;

namespace CountYourWords.Core;

public class WordCountApp(string filePath)
{
    public string Run()
    {
        var text = new FileReader(filePath).ReadAllText();

        if (text != null)
        {
            if (text.Length > 0)
            {
                return new WordCountMapper().WordCountMap(text).ToString();

            }
            else
            {
                return "Error: File is empty.";
            }
        }
        else
        {
            return "Error: File not found.";
        }
    }
}