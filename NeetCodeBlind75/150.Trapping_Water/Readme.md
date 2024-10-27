# Trapping Rain Water: A C# Solution
## Problem:

Given an array height of non-negative integers representing the height of each bar in a histogram, return the amount of water it can trap after raining.

## Solution:

We'll employ a two-pointer approach to efficiently calculate the trapped water.

### Algorithm:

#### 1.  Initialization:

- Initialize two pointers, left and right, pointing to the beginning and end of the height array, respectively.
- Initialize maxLeft and maxRight to store the maximum height seen so far from the left and right sides, respectively.
- Initialize collectedWater to store the total amount of water collected.
#### 2. Iterative Process:

- While left is less than right:
   - If the maximum height on the left side (maxLeft) is less than or equal to the maximum height on the right side (maxRight):
       -  Calculate the potential water that can be trapped at the current left position: min(maxLeft, maxRight) - height[left].
        - If the potential water is positive, add it to the collectedWater.
        - Update maxLeft to the maximum height seen so far from the left side.
        - Move the left pointer one position to the right.
   - Otherwise, if maxLeft is greater than maxRight:
     - Perform similar calculations for the right position.
     - Update maxRight and move the right pointer one position to the left. 
#### 3. Return Result:

- After the loop completes, return the collectedWater

### Time and Space Complexity:

 -**Time Complexity:** O(N), as we iterate through the array once.
- **Space Complexity:** O(1), as we use a constant amount of extra space.
#### Key Idea:
The core idea is to use two pointers to track the maximum height on both sides. By comparing these maximum heights, we can determine the amount of water that can be trapped at each position and accumulate it in the collectedWater variable.
