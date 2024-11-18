public class Graph
{
    private Dictionary<int, List<(int neighbor, int weight)>> adjacencyList = new();

    public void AddNode( int id )
    {
        if (!adjacencyList.ContainsKey(id))
            adjacencyList[id] = new List<(int neighbor, int weight)>();
    }

    public void AddEdge( int id1, int id2, int weight = 1 )
    {
        AddNode(id1);
        AddNode(id2);
        adjacencyList[id1].Add((id2, weight));
        adjacencyList[id2].Add((id1, weight));
    }

    public List<int> GetConnectedComponent( int startNode )
    {
        var visited = new HashSet<int>();
        var component = new List<int>();
        var stack = new Stack<int>();
        stack.Push(startNode);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (!visited.Contains(current))
            {
                visited.Add(current);
                component.Add(current);

                foreach (var (neighbor, _) in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }
        }

        return component;
    }

    public Dictionary<int, List<(int neighbor, int weight)>> GetAdjacencyList() => adjacencyList;
}