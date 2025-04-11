namespace CountYourWords.Interfaces;

public interface IWordCountMapper
{
    Dictionary<string, int> WordCountMap(string input);
}