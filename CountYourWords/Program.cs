using CountYourWords.Core;

namespace CountYourWords;
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(
            // Write word counts in console
            new WordCountApp("Resources/textdocument.txt").Run()
        );
    }
}