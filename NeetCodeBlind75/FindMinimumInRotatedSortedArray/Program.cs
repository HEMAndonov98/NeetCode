var solution = new Solution();
List<int[]> arguments = new List<int[]>();
int[] args1 = new int[] { 3, 4, 5, 1, 2 };
int[] args2 = new int[] { 4,5,6,7,0,1,2 };
int[] args3 = new int[] { 11,13,15,17 };

arguments.Add(args1);
arguments.Add(args2);
arguments.Add(args3);

foreach (var nums in arguments)
{
    Console.WriteLine(solution.FindMin(nums));
}

public class Solution {
    public int FindMin(int[] nums)
    {
        int res = nums[0];
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            if (nums[l] < nums[r])
            {
                if (nums[l] < res)
                {
                    res = nums[l];
                }
                break;
            }

            int m = r - l / 2;
            if (nums[m] < res)
            {
                res = nums[m];
            }

            if (nums[m] >= nums[l])
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return res;
    }
}