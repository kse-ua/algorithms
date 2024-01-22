List<List<int>> GetAllSubsetsBinary(List<int> set)
{
    var result = new List<List<int>>();
    var limit = Math.Pow(2, set.Count); // **
    for (int mask = 0; mask < limit; mask++)
    {
        var currentSubset = new List<int>();
        for (int i = 0; i < set.Count; i++)
        {
            if ((mask & (1 << i)) != 0)
            {
                currentSubset.Add(set[i]);
            }
        }
        
        result.Add(currentSubset);
    }

    return result;
}

List<List<int>>  GetAllSubsetsRecursive(List<int> set, int startIndex)
{
    // recursion exit 
    if (startIndex == set.Count)
    {
        return new List<List<int>>();
    }
    
    // find all subsets without first element
    var subsetsWithoutCurrent = GetAllSubsetsRecursive(set, startIndex + 1);

    // add those subsets to result
    var allSubsets = new List<List<int>>(subsetsWithoutCurrent);
    
    // for every subset add first element and to result
    foreach (var subset in subsetsWithoutCurrent)
    {
        var subsetWithElement = new List<int>(subset);
        subsetWithElement.Insert(0, set[startIndex]);
        allSubsets.Add(subsetWithElement);
    }

    return allSubsets;
}