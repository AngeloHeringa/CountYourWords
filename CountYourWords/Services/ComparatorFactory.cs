using CountYourWords.Interfaces;

namespace CountYourWords.Services;

public static class ComparatorFactory
{
    public static IComparator<T> Create<T>()
    {
        if (typeof(T) == typeof(string))
        {
            return (IComparator<T>)new StringComparator();
        }
        // else if (typeof(T) == typeof(int)) for example you can add more

        throw new NotSupportedException($"No comparator available for type {typeof(T)}");
    }
}
