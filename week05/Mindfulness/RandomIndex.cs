using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
public class RandomIndex
{
    private int _randomIndex;
    private List<int> _usedIndexes = new List<int>();

    public RandomIndex()
    {
        _randomIndex = 0; 
    }
    public static int ChooseUnusedRandom(RandomIndex index, int upperBound)
    {
        Random random = new Random();
        int randomIndex = random.Next(upperBound);

        while (index._usedIndexes.Contains(randomIndex))
        {
            randomIndex = random.Next(upperBound);
        }

        index._randomIndex = randomIndex;
        index._usedIndexes.Add(randomIndex);

        IEnumerable<int> requiredRange = Enumerable.Range(0, upperBound);
        if (requiredRange.All(num => index._usedIndexes.Contains(num)))
        {
            index._usedIndexes.Clear();
        }
        return randomIndex; 
    }
}