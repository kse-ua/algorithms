long CombinationsFormula(int n, int k)
{
    if (n == k || k == 0)
    {
        return 1;
    }

    return checked(FactorialDynamic(n) / (FactorialDynamic(k) * FactorialDynamic(n - k)));
}

long CombinationsRecursive(int n, int k)
{
    if (k == 0 || n == k)
    {
        return 1;
    }

    return CombinationsRecursive(n - 1, k) + CombinationsRecursive(n - 1, k - 1);
}

long CombinationsDynamic(int n, int k)
{
    var array = new long[n + 1, n + 1];
    for (int i = 0; i <= n; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            if (j == 0 || j == i)
            {
                array[i, j] = 1;
                continue;
            }

            array[i, j] = checked(array[i - 1, j] + array[i - 1, j - 1]);
        }
    }

    return array[n, k];
}