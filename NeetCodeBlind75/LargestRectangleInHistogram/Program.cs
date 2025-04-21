int findLargestArea(int[] heights)
{
    // We Initialize the maxArea to 0 as a default value
    // We also initialize the recPosStack to keep track of the indices of the heights
    //n is for simple iteration
    int maxArea = 0;
    int n = heights.Length;
    //We use the Stack to keep track of the indicies of the heights useful for the width and for retrieving the height
    Stack<int> recPosStack = new Stack<int>();

    //We iterate through the heights
    for (int i = 0; i < n; i++)
    {
        // We check if the stack is not empty and if the current height is less than the height at the top of the stack
        // If it is, this means that the stack is not monotonic and we need to pop the stack(all the rectangle to the left of the current height are larger)
        int currentHeight = heights[i];
        while (recPosStack.Count > 0 && currentHeight < heights[recPosStack.Peek()])
        {
            // We calculate the area of the rectangle
            int smallerRecPos = recPosStack.Pop();
            int smallerRecHeight = heights[smallerRecPos];
            int width = recPosStack.Count == 0 ? i : i - recPosStack.Peek() - 1;
            int currentArea = smallerRecHeight * width;
            // We check if the area is larger than the maxArea
            maxArea = Math.Max(maxArea, currentArea);
        }
        recPosStack.Push(i);
    }
    // All the values that are left in the stack should be of the indecies of heights that are growing monotonically
    // We will pop until the stack is empty and knowing the width of the heights array we can calculate the area
    while (recPosStack.Count > 0)
    {
        int currentRecPos = recPosStack.Pop();
        int currentHeightValue = heights[currentRecPos];
        int width = recPosStack.Count == 0 ? n : n - recPosStack.Peek() - 1;
        int currentArea = currentHeightValue * width;
        maxArea = Math.Max(maxArea, currentArea);
    }
    return maxArea;
}

// Test the function with an example
int[] heights = { 7, 1, 7, 2, 2, 4 };
int largestArea = findLargestArea(heights);
Console.WriteLine("The largest area is: " + largestArea);
// The largest area should be is: 8

