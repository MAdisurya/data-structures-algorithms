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
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
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

        Console.WriteLine("BFS starting from 0");

        g.BFS(0, 4);

        Console.WriteLine();
    }
}
