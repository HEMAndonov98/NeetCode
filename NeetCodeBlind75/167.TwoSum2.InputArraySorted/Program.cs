int[] TwoSum(int[] numbers, int target)
{
    int l = 0;
    int r = numbers.Length - 1;

    while (l < r)
    {
        int result = numbers[l] + numbers[r];

        if (result > target)
        {
            r--;
        }
        else if (result < target)
        {
            l++;
        }
        else
        {
            break;
        }
    }

    return new[] { l + 1, r + 1 };
}