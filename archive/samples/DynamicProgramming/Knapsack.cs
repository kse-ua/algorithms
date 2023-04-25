
Console.WriteLine(KnapsackDynamic(4, new List<Item>()
{
    new Item(1, 600),
    new Item(4, 1300),
    new Item(3, 900)
}));

int Knapsack(int capacity, List<Item> items, int n)
{
    if (capacity == 0 || n == 0)
    {
        return 0;
    }

    if (items[n - 1].Weight > capacity)
    {
        return Knapsack(capacity, items, n - 1);
    }
    
    var valueIfNotIncluded = Knapsack(capacity, items, n - 1);
    var valueIfIncluded = items[n - 1].Value + Knapsack(capacity - items[n - 1].Weight, items, n - 1);

    return Math.Max(valueIfIncluded, valueIfNotIncluded);
}

int KnapsackDynamic(int capacity, List<Item> items)
{
    var n = items.Count;
    var array = new int[n + 1, capacity + 1];
    for (var i = 0; i <= n; i++)
    {
        for (var w = 0; w <= capacity; w++)
        {
            if (i == 0 || w == 0)
            {
                array[i, w] = 0;
            }
            else if (items[i - 1].Weight <= w)
            {
                array[i, w] = Math.Max(array[i - 1, w], items[i - 1].Value + array[i - 1, w - items[i - 1].Weight]);
            }
            else
            {
                array[i, w] = array[i - 1, w];
            }
        }
    }

    return array[n, capacity];
}


class Item
{
    public int Weight { get; set; }
    
    public int Value { get; set; }

    public Item(int weight, int value)
    {
        Weight = weight;
        Value = value;
    }
}