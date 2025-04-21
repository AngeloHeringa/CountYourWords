using CountYourWords.Interfaces;

namespace CountYourWords.Services;

public class StringComparator() : Comparator<string, char>([
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
],str=>str.ToLower().ToCharArray())
{
    // protected override int? RecurringCompare(IEnumerable<char> chars1, IEnumerable<char> word2, int iteration)
    // {
    //     // If we've reached the end of both words
    //     if (iteration >= word1.Length && iteration >= word2.Length)
    //     {
    //         return 0;
    //     }
    //
    //     // If either word1 or word2 is of shorter length
    //     if (iteration >= word1.Length)
    //     {
    //         return -1;
    //     }
    //     if (iteration >= word2.Length)
    //     {
    //         return 1;
    //     }
    //
    //     char char1 = word1[iteration];
    //     char char2 = word2[iteration];
    //
    //     int? index1 = Comparers.IndexOf(char1);
    //     int? index2 = Comparers.IndexOf(char2);
    //
    //     // If either char is not in the alphabet
    //     if (index1 == -1 || index2 == -1)
    //     {
    //         return null;
    //     }
    //
    //     if (index1 == index2)
    //     {
    //         return RecurringCompare(word1, word2, iteration + 1);
    //     }
    //
    //     return index1 < index2 ? -1 : 1;
    // }
}