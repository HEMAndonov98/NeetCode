static int tasks(int n, List<int> a, List<int> b)
{
    int[] inDegree;
    List<int>[] graph = CreateDAP(n, a, b, out inDegree);
    bool[] visited = new bool[n + 1];
    Dictionary<int, List<int>> directedGraph = new Dictionary<int, List<int>>();


    return 0;
}

static List<int>[] CreateDAP(int n, List<int> a, List<int> b, out int[] inDegree)
{
    Dictionary<int, List<int>> nodeNeighbours = new Dictionary<int, List<int>>();
    inDegree = new int[n + 1];

    for (int i = 0; i <= n; i++)
        graph[i] = new List<int>();

    for (int i = 0; i < a.Count; i++)
    {
        int from = b[i];
        int to = a[i];

        graph[from].Add(to);
        inDegree[to]++;
    }
    return graph;
}

static bool DFSCycleCheck(int node, bool[] visited, List<int>[] graph)
{
    Stack<int> dfsStack = new Stack<int>();
    dfsStack.Push(node);

    while (dfsStack.Count > 0)
    {
        int curr = dfsStack.Pop();
        if (visited[curr]) return true;
        visited[curr] = true;

        foreach (int neighbour in graph[curr])
        {
            dfsStack.Push(neighbour);
        }
    }

    return false;
}
List<int> a = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<int> b = new List<int> { 9, 8, 10, 4, 9, 1, 3, 5, 9 };

Console.WriteLine(tasks(10, a, b));