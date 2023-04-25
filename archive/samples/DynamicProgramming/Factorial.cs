long FactorialRecursive(int n)
{
    if (n <= 1)
    {
        return 1;
    }

    return n * FactorialRecursive(n - 1);
}

long FactorialDynamic(int n)
{
    var result = 1L;
    for (int i = 2; i <= n; i++)
    {
        result = checked(result * i);
    }

    return result;
}
