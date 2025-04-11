using CountYourWords.Services;
using System;
using System.IO;
using System.Linq;

namespace CountYourWords
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Path to text document
            var filePath = "Resources/textdocument.txt";
            // Save file contents to string
            var text = new FileReader(filePath).ReadAllText();
            
            // Check if file exists / not empty
            if (text != null)
            {
                // Get key value map with words and occurence counts
                var wordCountMap = new WordCountMapper().WordCountMap(text);
                // Print results in console
                Console.WriteLine($"Number of words: {wordCountMap.Sum(entry => entry.Value)}\n");

                foreach (var entry in wordCountMap)
                {
                    Console.WriteLine($"{entry.Key} {entry.Value}");
                }
            }
            else
            {
                Console.WriteLine($"Error: File {filePath} not found or empty.");
            }
        }
    }
}