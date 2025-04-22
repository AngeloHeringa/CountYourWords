using CountYourWords.Models;

namespace CountYourWords.Interfaces;

public interface IWordCountMapper
{
    MapResult WordCountMap(string input);
}