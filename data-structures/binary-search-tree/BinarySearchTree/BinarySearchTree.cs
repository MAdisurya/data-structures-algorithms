using System;

class BinarySearchTree<T> where T : IComparable
{
    /// <summary>
    /// Internal Node class
    /// </summary>
    private class Node
    {
        public T data;
        public Node left;
        public Node right;

        public Node(T data, Node left = null, Node right = null)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }

    // For tracking the amount of nodes in the BST
    private int nodeCount = 0;

    // Reference to the root node of the BST
    private Node root = null;

    /// <summary>
    /// Returns the amount of nodes in the BST
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return nodeCount;
    }

    /// <summary>
    /// Checks if BST is empty and returns either
    /// true or false.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return Size() == 0;
    }

    /// <summary>
    /// Adds a node into the BST.
    /// Returns true if successfully added.
    /// </summary>
    public bool Add(T data)
    {
        // Check if data already exists in the BST
        // If it does, we ignore it and return false
        if (Contains(data))
        {
            return false;
        }
        // Otherwise, add the data to the BST
        else
        {
            root = Add(root, data);
            nodeCount++;
            return true;
        }
    }

    /// <summary>
    /// Recursive method that recursively traverses the BST
    /// and inserts a node in the correct subtree.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private Node Add(Node node, T data)
    {
        // Handle base case where we found a leaf node
        if (node == null)
        {
            node = new Node(data, null, null);
        }
        // Otherwise, we perform the recursion and traverse
        // the subtrees to insert the new node
        else
        {
            // if data < node.data
            if (data.CompareTo(node.data) < 0)
            {
                // We dig into the left subtree
                node.left = Add(node.left, data);
            }
            else
            {
                // We dig into the right subtree
                node.right = Add(node.right, data);
            }
        }

        return node;
    }

    /// <summary>
    /// Removes a node from the BST.
    /// Returns true if successfully removed.
    /// </summary>
    public bool Remove(T data)
    {
        return false;
    }

    /// <summary>
    /// Returns true if the node with passed data
    /// exists in the BST.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool Contains(T data)
    {
        return Contains(root, data);
    }

    /// <summary>
    /// Recursive method that recursively checks the nodes
    /// in the BST for one that contains the passed data.
    /// Assuming that the BST is Balanced, the Time Complexity
    /// would be: O(log(n)).
    /// Since we cut the amount of nodes we will go through by half
    /// after every recursion.
    /// </summary>
    private bool Contains(Node node, T data)
    {
        // Handle the base case where we
        // reached the bottom of the BST
        if (node == null) return false;

        // Store the result of the comparison between
        // the current node.data and the passed data
        int comparison = data.CompareTo(node.data);

        // If the data < node.data we want to dig left
        // because lower values go on the left side of the BST
        if (comparison < 0)
        {
            // We recursively call Contains again, but pass it the
            // current nodes left child node this time
            return Contains(node.left, data);
        }
        // Otherwise if the data > node.data, so we want to dig right
        else if (comparison > 0)
        {
            return Contains(node.right, data);
        }
        // Otherwise if the data == node.data, then BST contains the node
        // we are looking for
        else
        {
            return true;
        }
    }

    public T PreorderTraversal()
    {
        return default;
    }

    public T PostorderTraversal()
    {
        return default;
    }

    public T InorderTraversal()
    {
        return default;
    }

    public T LevelorderTraversal()
    {
        return default;
    }
}

class MainClass
{
    public static void Main()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        Console.WriteLine("Binary Search Tree (BST)");
        Console.WriteLine("-------------------------");
        Console.WriteLine();

        Console.WriteLine($"Size: {bst.Size()}");
        Console.WriteLine($"Empty?: {bst.IsEmpty()}");
        Console.WriteLine();

        Console.WriteLine($"Add 5: {bst.Add(5)}");
        Console.WriteLine($"Add 7: {bst.Add(7)}");
        Console.WriteLine($"Add 6: {bst.Add(6)}");
        Console.WriteLine($"Add 6: {bst.Add(6)}");
        Console.WriteLine($"Add 9: {bst.Add(9)}");
        Console.WriteLine($"Add 3: {bst.Add(3)}");
        Console.WriteLine($"Add 3: {bst.Add(3)}");
        Console.WriteLine($"Add 2: {bst.Add(2)}");
        Console.WriteLine($"Add 4: {bst.Add(4)}");

        Console.WriteLine();
        Console.WriteLine($"Size: {bst.Size()}");
        Console.WriteLine($"Empty?: {bst.IsEmpty()}");
        Console.WriteLine();

        Console.WriteLine($"Contains 3: {bst.Contains(3)}");
        Console.WriteLine($"Contains 9: {bst.Contains(9)}");
        Console.WriteLine($"Contains 10: {bst.Contains(10)}");
    }
}
