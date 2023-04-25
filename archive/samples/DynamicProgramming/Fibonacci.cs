int FibonacciRecursive(int n)
{
    if (n <= 1)
    {
        return n;
    }

    if (n == 2)
    {
        return 1;
    }

    return checked(FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2));
}

long FibonacciDynamic(int n)
{
    if (n <= 1)
    {
        return n;
    }

    if (n == 2)
    {
        return 1;
    }
    
    var array = new long[n + 1];
    array[0] = 0;
    array[1] = array[2] = 1;
    for (int i = 3; i <= n; i++)
    {
        array[i] = array[i - 1] + array[i - 2];
    }

    return array[n];
}
