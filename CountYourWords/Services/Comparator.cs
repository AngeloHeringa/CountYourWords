using CountYourWords.Interfaces;

namespace CountYourWords.Services;

public abstract class Comparator<X, Y>(List<Y> comparers, Func<X, IEnumerable<Y>> decomposer) : IComparator<X>
{
    public int? Compare(X value1, X value2)
    {
        // Slice the values into arrays, so they can be compared across multiple types using the decomposer parameter function
        var sequencedValue1 = decomposer(value1);
        var sequencedValue2 = decomposer(value2);
    
        // Compare recurringly until a result has been computed
        return RecurringCompare(sequencedValue1.ToList(), sequencedValue2.ToList(), 0);
    }

    private int? RecurringCompare(List<Y> seq1, List<Y> seq2, int index)
    {
        // If we've reached the end of both words
        if (index >= seq1.Count && index >= seq2.Count) return 0;
        
        // If either seq1 or seq2 is of shorter length
        if (index >= seq1.Count) return -1;
        if (index >= seq2.Count) return 1;
        
        // Variable of type Y to compare with the comparers
        var unit1 = seq1[index];
        var unit2 = seq2[index];

        // Get the index to base the result on
        var index1 = comparers.IndexOf(unit1);
        var index2 = comparers.IndexOf(unit2);

        // If unit doesn't exist in Comparers
        if (index1 == -1 || index2 == -1) return null;
        
        // If units have the same index in comparers
        if (index1 == index2) return RecurringCompare(seq1, seq2, index + 1);

        // Return -1 if unit1 is before unit2 in comparers, else return 1
        return index1 < index2 ? -1 : 1;
    }
}