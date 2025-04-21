Console.WriteLine(String.Join(", ", MaxSlidingWindow([1, 2, 1, 0, 4, 2, 6], 3))); // output: 2, 2, 4, 4, 6
Console.WriteLine(String.Join(", ", MaxSlidingWindow([1, -1], 1)));


int[] MaxSlidingWindow(int[] nums, int k)
{

    if (nums.Length < 1)
    {
        return new int[0];
    }

    if (k <= 0)
    {
        return new int[0];
    }
    int[] largestValue = new int[nums.Length - k + 1];
    // Initialize the first element of largestValue with the first element of nums
    // and we will find the maximum in this window
    // and assign it to the first element of largestValue
    for (int i = 0; i < largestValue.Length; i++)
    {
        largestValue[i] = -1000;
    }

    for (int i = 0; i <= nums.Length - k; i++)
    {
        for (int j = i; j < k + i; j++)
        {
            int currentElement = nums[j];

            if (currentElement > largestValue[i])
            {
                largestValue[i] = currentElement;
            }
        }
    }

    return largestValue;
}


