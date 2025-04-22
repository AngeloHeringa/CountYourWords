using CountYourWords.Interfaces;

namespace CountYourWords.Services;

public class StringComparator() : Comparator<string, char>([
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
],str=>str.ToLower().ToCharArray());