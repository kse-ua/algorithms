// this is long version with basic C# structures
List<List<string>> MaxCover(List<string> universe, List<List<string>> sets)
{
    var uncovered = universe.ToList();
    var result = new List<List<string>>();
    while (uncovered.Any())
    {
        var maxUncovered = 0;
        List<string> maxSet = null;
        foreach (var set in sets)
        {
            var uncoveredElements = UncoveredElementsFrom(set);
            if (uncoveredElements > maxUncovered)
            {
                maxSet = set;
                maxUncovered = uncoveredElements;
            }
        }
        result.Add(maxSet);
        foreach (var element in maxSet)
        {
            uncovered.Remove(element);
        }

        sets.Remove(maxSet);
    }

    return result;

    int UncoveredElementsFrom(List<string> set)
    {
        var count = 0;
        foreach (var element in set)
        {
            if (uncovered.Contains(element))
            {
                count++;
            }
        }

        return count;
    }
}

//or shorter version using LINQ
List<List<string>> MaxCover(List<string> universe, List<List<string>> sets)
{
    var uncovered = universe.ToList();
    var result = new List<List<string>>();
    while (uncovered.Any())
    {
        var set = sets.OrderByDescending(set => uncovered.Count(element => set.Contains(element))).First();
        result.Add(set);
        foreach (var element in set)
        {
            uncovered.Remove(element);
        }

        sets.Remove(set);
    }

    return result;
}

//usage is similar
var covered = MaxCover(new List<string>(){"A", "B", "C", "D"}, new List<List<string>>()
{
    new List<string>(){"A", "B", "C"},
    new List<string>(){"A", "B"},
    new List<string>() {"B", "D"},
});

foreach (var coveredSet in covered)
{
    Console.WriteLine(string.Join(",", coveredSet));
}