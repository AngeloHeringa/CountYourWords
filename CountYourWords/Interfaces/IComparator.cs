namespace CountYourWords.Interfaces;

public interface IComparator<X>
{
    int? Compare(X value1, X value2);
}