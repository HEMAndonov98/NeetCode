int Trap(int[] height)
{
    if (height.Length < 3) return 0;
    
    int l = 0, r = height.Length - 1;
    int maxLeft = height[l];
    int maxRight = height[r];
    int collectedWater = 0;

    while (l <= r)
    {
        int currentCollected = 0;

        if (maxLeft <= maxRight)
        {
            currentCollected = maxLeft - height[l];
            if(height[l] > maxLeft) maxLeft = height[l];
            l++;
        }
        else if (maxLeft > maxRight)
        {
            currentCollected = maxRight - height[r];
            if(height[r] > maxRight) maxRight = height[r];
            r--;
        }
        if(currentCollected > 0) collectedWater += currentCollected;
    }
    
    return collectedWater;
}
