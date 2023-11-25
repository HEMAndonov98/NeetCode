int[] nums = new[] { 1,3,5 };
int target = 1;

var sol = new Solution();
var result = sol.Search(nums, target);

Console.WriteLine(result);


public class Solution {
    public int Search(int[] nums, int target)
    {
        int result;
        int l = 0;
        int r = nums.Length - 1;

        //In case array is not rotated or was rotated such that it was returned to its original
        //position we just use a basic binary search to find the target.
        if (nums[l] <= nums[r])
        {
            return BinarySearch(nums, l, r, target);
        }

        //Find the pivot point where the array was rotated
        int pivot = FindPivot(nums, l, r);

        if (target > nums[r])
        {
            result = BinarySearch(nums, l, pivot, target);
        }
        else
        {
            result = BinarySearch(nums, (pivot + 1), r, target);
        }
        return result;
    }

    //Generic binary search method
    public int BinarySearch(int[] nums, int l, int r, int target)
    {
        int result = -1;
        
        //iterative approach
        while (l <= r)
        {
            int m = (l + r) / 2;

            if (nums[m] == target)
            {
                result = m;
            }

            //If our current middle array value is bigger than our searched target
            //we will search the left section of our array for the target
            if (nums[m] > target)
            {
                r = m - 1;
            }
            //Else we will search the right section
            else
            {
                l = m + 1;
            }
        }

        return result;
    }

    //Like Binary Search but its task is to find the pivot index of the nums array
    public int FindPivot(int[] nums, int l, int r)
    {
        //we set a base value for the pivot
        int pivot = -1;
        
        //Instead of using recursion I used an iterative approach to avoid large arrays
        while (l <= r)
        {
            int m = (l + r) / 2;
            
            //In case the next element in the array is not sorted we have found our pivot
            if (nums[m + 1] < nums[m])
            {
                pivot = m;
                break;
            }

            //We check if our current array section is not sorted
            if (nums[l] > nums[m])
            {
                //In this case we will have to search the left section of our array
                //from our current middle to find the pivot
                r = m - 1;
            }
            else
            {
                //In this case our pivot is somewhere on the right section of our array
                //from our current middle.
                l = m + 1;
            }
        }

        return pivot;
    }
}