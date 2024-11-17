namespace MunicipalAppProgPoe.Utils
{
    public class Graph
    {
        private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

        public void AddNode( int id )
        {
            if (!adjacencyList.ContainsKey(id))
                adjacencyList[id] = new List<int>();
        }

        public void AddEdge( int id1, int id2 )
        {
            AddNode(id1);
            AddNode(id2);
            adjacencyList[id1].Add(id2);
            adjacencyList[id2].Add(id1);
        }

        public List<int> GetConnections( int id )
        {
            return adjacencyList.ContainsKey(id) ? adjacencyList[id] : new List<int>();
        }

        // Placeholder for Minimum Spanning Tree (MST) implementation
        public List<int> MinimumSpanningTree( int startNode )
        {
            // Implement MST algorithm (e.g., Prim's or Kruskal's) if required
            return new List<int>();
        }
    }
}
