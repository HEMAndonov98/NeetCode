// This program calculates the number of days until a warmer temperature for each day in the input array.
// It uses a stack to keep track of the indices of the temperatures that have not yet found a warmer day.
// The algorithm iterates through the temperatures, and for each temperature, it checks if there are any previous temperatures
// that are lower than the current temperature. If so, it pops those indices from the stack and calculates the difference in days.
// Finally, it returns an array with the number of days until a warmer temperature for each day.
int[] DailyTemperatures(int[] temperatures)
{
    // This array will hold the result
    // The length of the result array is the same as the input array
    int[] result = new int[temperatures.Length];
    // This stack will hold the indices of the temperatures
    Stack<int> tempIdnStack = new Stack<int>();

    // Iterate through the temperatures
    // The loop variable 'i' represents the current index in the temperatures array
    for (int i = 0; i < temperatures.Length; i++)
    {
        // The current temperature is stored in the variable 'currentTemp'
        int currentTemp = temperatures[i];
        // While there are indices in the stack and the current temperature is greater than the temperature at the index on top of the stack
        // This means we have found a warmer temperature for the index at the top of the stack
        while (tempIdnStack.Count > 0 && temperatures[tempIdnStack.Peek()] < currentTemp)
        {
            // Pop the index from the stack
            int prevIndex = tempIdnStack.Pop();
            // Calculate the number of days until a warmer temperature
            result[prevIndex] = i - prevIndex;
        }
        // Push the current index onto the stack
        // This means we have not yet found a warmer temperature for this index
        tempIdnStack.Push(i);
    }
    // retrun the result array
    return result;
}

System.Console.WriteLine(String.Join(", ", DailyTemperatures(new int[] { 30, 38, 30, 36, 35, 40, 28 })));