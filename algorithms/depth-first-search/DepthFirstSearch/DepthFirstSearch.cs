using System;
using System.Collections.Generic;

class Graph
{
    // The number of vertices
    private int v = 0;
    // Array of lists for adjacency list representation
    private List<int>[] adj;
    // Array to store the visited nodes/vertices
    private bool[] visited;

    /// <summary>
    /// Constructor for Graph object
    /// </summary>
    public Graph(int _V)
    {
        // The number of vertices the graph will have
        v = _V;
        // Initialize the array of Lists of size _V
        adj = new List<int>[_V];
        // Initialize the array of visited bools
        visited = new bool[_V];

        // Then we initialize the Lists within the adj array
        for (int i = 0; i < _V; i++)
        {
            adj[i] = new List<int>();
        }
    }

    /// <summary>
    /// Adds an edge to the graph
    /// </summary>
    public void AddEdge(int v, int w)
    {
        // Add w to v's list
        adj[v].Add(w);
    }

    /// <summary>
    /// Recursive method for traversing the graph
    /// </summary>
    public void DFS(int v)
    {
        // Need to have a base case to avoid overflow
        // In this case, we check if the node/vertices has been visited
        // If it has, then we return
        if (visited[v]) return;

        // If not, then we need to make sure that we set that this node/vertices
        // has been visited
        visited[v] = true;
        Console.WriteLine(v + " ");

        // Get the neighbor/edges of the current node/vertice
        // Then we loop through each node and invoke DFS
        // with the neighboring nodes
        List<int> neighbors = adj[v];
        foreach (int next in neighbors)
        {
            // Recursively called here
            DFS(next);
        }
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        // graph used for DFS example:
        // https://raw.githubusercontent.com/MAdisurya/data-structures-algorithms/master/algorithms/depth-first-search/DepthFirstSearch/images/graph-dfs-example.png

        Graph graph = new Graph(12);

        graph.AddEdge(0, 9);
        graph.AddEdge(0, 1);
        graph.AddEdge(1, 8);
        graph.AddEdge(2, 2);
        graph.AddEdge(3, 2);
        graph.AddEdge(3, 4);
        graph.AddEdge(3, 7);
        graph.AddEdge(4, 4);
        graph.AddEdge(5, 3);
        graph.AddEdge(6, 5);
        graph.AddEdge(7, 10);
        graph.AddEdge(7, 6);
        graph.AddEdge(8, 7);
        graph.AddEdge(9, 8);
        graph.AddEdge(10, 11);
        graph.AddEdge(11, 7);

        graph.DFS(0);

        // Expected Output
        // ----------------
        // 0
        // 9
        // 8
        // 7
        // 10
        // 11
        // 6
        // 5
        // 3
        // 2
        // 4
        // 1
    }
}