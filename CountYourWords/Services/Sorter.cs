namespace CountYourWords.Services;

public abstract class Sorter<T>
{
    public static List<T> SortWithComparator(IEnumerable<T> words)
    {
        var list = words.ToList();

        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                var result = ComparatorFactory.Create<T>().Compare(list[i], list[j]);
                if (result == 1) // list[i] > list[j]
                {
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }
        }

        return list;
    }
}