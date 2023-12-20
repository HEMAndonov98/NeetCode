// There is an integer array nums sorted in ascending order (with distinct values).
// Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length)
// such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed).
// For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
//Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
//You must write an algorithm with O(log n) runtime complexity.
var test = new Solution();
var testArray = new int[] { 5, 1, 3 };
var testTarget = 3;

Console.WriteLine(test.Search(testArray, testTarget));



public class Solution {
    public int Search(int[] nums, int target)
    {
        
        int l = 0;
        int r = nums.Length - 1;
        
        //Default output if target is not found
        int result = -1;
        while (l <= r)
        {
            int m = (l + r) / 2;

            //If this check is ture it means our window from l to m in the array
            //is sorted!
            if (nums[m] >= nums[l])
            {
                //If this check passes our target is somewhere within this window
                if (target >= nums[l] && target <= nums[m])
                {
                    result = this.BinarySearch(nums, l, m, target);
                    break;
                }
                l = m + 1;
            }
            else
            {
                if (target >= nums[m] && target <= nums[r])
                {
                    result = this.BinarySearch(nums, m, r, target);
                    break;
                }
                r = m;
            }
        }
        
        return result;
    }

    public int BinarySearch(int[] nums, int l, int r, int target)
    {
        int result = -1;
        while (l <= r)
        {
            int m =  (l + r) / 2;

            if (target < nums[m])
            {
                r = m - 1;
            }
            else if (target > nums[m])
            {
                l = m + 1;
            }
            else
            {
                result = m;
                break;
            }
        }

        return result;
    }
}