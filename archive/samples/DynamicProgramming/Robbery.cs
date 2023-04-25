Console.WriteLine(RobDynamic(new []{5, 10, 15, 20}));

int Rob(int[] nums)
{
    return FindRob(nums, nums.Length - 1);
}

int FindRob(int[] nums, int i)
{
    if (i < 0)
    {
        return 0;
    }

    return Math.Max(FindRob(nums, i - 2) + nums[i], FindRob(nums, i - 1));
}

int RobDynamic(int[] nums) {
    if (nums.Length == 0)
    {
        return 0;
    }
    
    var memo = new int[nums.Length + 1];
    memo[0] = 0;
    memo[1] = nums[0];
    for (int i = 1; i < nums.Length; i++) {
        int val = nums[i];
        memo[i+1] = Math.Max(memo[i], memo[i-1] + val);
    }
    return memo[nums.Length];
}

 int RobDynamicEffective(int[] nums) {
    if (nums.Length == 0)
    {
        return 0;
    }
    int previous = 0;
    int beforePrevious = 0;
    foreach (var number in nums)
    {
        int tmp = previous;
        previous = Math.Max(beforePrevious + number, previous);
        beforePrevious = tmp;
    }
    return previous;
}