using System;
using System.Collections.Generic;

class Graph
{
    // To track the number of vertices in the graph
    private int size;
    // Adjacency list representing the graph
    private List<int>[] adj;

    // Constructor
    public Graph(int _Size)
    {
        size = _Size;
        adj = new List<int>[_Size];

        // Initialize the lists in adj
        for (int i = 0; i < _Size; i++)
        {
            adj[i] = new List<int>();
        }
    }

    /// <summary>
    /// Returns the number of verticies in the graph
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return size;
    }

    /// <summary>
    /// Returns whether the graph is empty or not
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return size == 0;
    }

    /// <summary>
    /// Reconstructs shortest path from start vertex to end vertex
    /// by backtracking from the end vertex and traversing it's parent.
    /// </summary>
    /// <param name="s">The start vertex</param>
    /// <param name="e">The end vertex</param>
    /// <param name="prev">The array where the parents of each vertex is stored</param>
    /// <returns>Shortest path from start to end</returns>
    private List<int> ReconstructPath(int s, int e, int[] prev)
    {
        // For storing and returning the reconstructed path
        List<int> path = new List<int>();

        // We iterate and traverse the prev array starting from the end vertex
        // The idea is to backtrack from the end vertex by getting it's parent
        // vertex and storing it into the path array
        // We continue this process until we've reached a vertex with no parent
        for (int at = e; at > -1; at = prev[at])
        {
            path.Add(at);
        }

        // Reverse the path so we have s > e, not e > s
        //ReverseArray(ref path, size);
        path.Reverse();

        // Handle case where the iteration may not have reached the start vertex
        // (This is possible if we have a disjoint graph)
        // Just need to check if the first item is the same as the start vertex
        if (path[0] == s)
        {
            return path;
        }

        return null;
    }

    /// <summary>
    /// Adds an edge into the graph
    /// </summary>
    public void AddEdge(int v, int w)
    {
        // We add w to v's list
        // v represents the vertices of the graph
        // w represents the edges (basically the connections between vertices)
        adj[v].Add(w);

        Console.WriteLine($"Added {w} to {v}");
    }

    /// <summary>
    /// The main method for doing BFS traversal for the graph
    /// </summary>
    /// <param name="s">Vertex to start from</param>
    /// <param name="e">Vertex to end on</param>
    public void BFS(int s, int e)
    {
        // Create a new array of booleans
        // Because we need to track which vertices have been visited
        // since graphs can be cyclical
        bool[] visited = new bool[size];
        // Initialize prev array
        // Essentially, it's an array that stores references to
        // the parents of each vertex (so we can backtrack and
        // find the shortest path)
        // It's not necessary for the BFS implementation, but
        // necessary for reconstructing a path to find the shortest
        // path
        int[] prev = new int[size];

        for (int i = 0; i < size; i++)
        {
            // We initially set all the elements in visited to false
            visited[i] = false;
            // We also initially set all elements in prev to
            // a value that won't exist as a vertex in the graph
            prev[i] = -1;
        }

        // Queue for enqueueing and dequeueing the vertices
        Queue<int> q = new Queue<int>();

        // Enqueue the first vertex (s), and mark as visited
        q.Enqueue(s);
        visited[s] = true;

        // We want to keep traversing the graph as long as
        // there are items inside the queue
        while (q.Count > 0)
        {
            // Dequeue and store it's value
            int vertex = q.Dequeue();
            Console.Write($"{vertex} ");

            // Then we want to get all the vertex's neighbors/children
            // and add them to the queue
            foreach (int next in adj[vertex])
            {
                // Check if the vertex has been visited or not
                if (!visited[next])
                {
                    // If not, we enqueue, mark the vertex
                    // as visited, and also append the parent
                    // vertex into the prev array
                    q.Enqueue(next);
                    visited[next] = true;
                    prev[next] = vertex;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Reconstructed Path from {s} to {e}:");

        foreach (int i in ReconstructPath(s, e, prev))
        {
            Console.Write($"{i} ");
        }
    }
}

class MainClass
{
    public static void Main()
    {
        // Refer to this image for graph we will be using:
        // https://raw.githubusercontent.com/MAdisurya/data-structures-algorithms/master/algorithms/breadth-first-search/BreadthFirstSearch/bfs-example.JPG

        Graph g = new Graph(13);

        Console.WriteLine("Breadth First Traversal (BFS)");
        Console.WriteLine("-----------------------------");
        Console.WriteLine();


        g.AddEdge(0, 7);
        g.AddEdge(0, 9);
        g.AddEdge(0, 11);
        g.AddEdge(3, 2);
        g.AddEdge(3, 4);
        g.AddEdge(6, 5);
        g.AddEdge(7, 3);
        g.AddEdge(7, 6);
        g.AddEdge(8, 1);
        g.AddEdge(8, 12);
        g.AddEdge(9, 8);
        g.AddEdge(9, 10);
        g.AddEdge(10, 1);
        g.AddEdge(12, 2);
        Console.WriteLine();

        Console.WriteLine("BFS starting from 0:");

        g.BFS(0, 4);

        Console.WriteLine();

        // Expected Output:
        // -----------------
        // BFS starting from 0:
        // 0 7 9 11 3 6 8 10 2 4 5 1 12
        // Reconstructed Path from 0 to 4:
        // 0 7 3 4
    }
}
