using System;

int ReturnCars(int target, int[] position, int[] speed)
{
    int n = position.Length;
    (int pos, double time)[] posTime = new (int, double)[n];
    for (int i = 0; i < n; i++)
    {
        posTime[i] = (position[i], (double)(target - position[i]) / speed[i]);
    }

    Array.Sort(posTime, (a, b) => b.pos.CompareTo(a.pos));
    int fleets = 0;
    double lastTime = 0;
    for (int i = 0; i < n; i++)
    {
        double currentTime = posTime[i].time;
        if (currentTime > lastTime)
        {
            fleets++;
            lastTime = currentTime;
        }
    }

    return fleets;
}

Console.WriteLine(ReturnCars(12, new int[] { 10, 8, 0, 5, 3 }, new int[] { 2, 4, 1, 1, 3 }));
Console.WriteLine(ReturnCars(10, new int[] { 4, 1, 0, 7 }, new int[] { 2, 2, 1, 1 }));