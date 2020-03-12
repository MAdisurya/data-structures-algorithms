using System;
using System.Collections.Generic;

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
    /// Recursive method that traverses the BST
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
        // Check if node we want to remove
        // actually exists in the BST
        if (Contains(data))
        {
            root = Remove(root, data);
            nodeCount--;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Recursive remove method that traverses the BST
    /// and removes the desired node.
    /// </summary>
    private Node Remove(Node node, T data)
    {
        if (node == null) return null;

        // Store the result of the comparison between
        // the current node.data and the passed data
        int comparison = data.CompareTo(node.data);

        // If the current value we're looking for
        // is smaller than the current node.data
        // dig into the left subtree
        if (comparison < 0)
        {
            node.left = Remove(node.left, data);
        }
        // Otherwise, dig into the right subtree
        else if (comparison > 0)
        {
            node.right = Remove(node.right, data);
        }
        // Otherwise, we found the node we want to remove
        else
        {
            // Handle case where only right subtree exists
            // in current node
            // Here, we just swap the node we are removing
            // with it's right child
            if (node.left == null)
            {
                // We need to get a reference to the right child node
                // so we can point to it from the current nodes parent node
                Node rightNode = node.right;

                // Remove the current node, clean up memory so we don't
                // have any memory leaks
                node.data = default;
                node = null;

                return rightNode;
            }
            // Handle the case where only left subtree exists
            // in current node
            else if (node.right == null)
            {
                Node leftNode = node.left;

                node.data = default;
                node = null;

                return leftNode;
            }
            // Handle the case where both left and right subtree exists
            // In this case, we need to choose which node we want to swap with
            // the current node.
            // We have 2 options, either pick the largest node from the left subtree
            // or pick the smallest node from the right subtree
            // I will implement both, but comment one out
            else
            {
                // Option 1: Largest node from the left subtree
                // --------------------------------------------

                // Find the right most node in the left subtree
                // and get a reference to the node
                Node tempNode = FindMax(node.left);

                // Swap the data
                node.data = tempNode.data;

                // Then we need to traverse the left subtree and
                // remove the node we swapped the data with
                // this is so we don't have duplicate nodes in the BST
                node.left = Remove(node.left, tempNode.data);

                // Option 2: Smallest node from the right subtree
                // --------------------------------------------

                // Node tempNode = FindMin(node.right);
                // node.data = tempNode.data;
                // node.right = Remove(node.right, tempNode.data);
            }
        }

        return node;
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

    /// <summary>
    /// Helper method to find the left most node in a subtree
    /// (should have the smallest value)
    /// </summary>
    private Node FindMin(Node node)
    {
        while (node.left != null) node = node.left;
        return node;
    }

    /// <summary>
    /// Helper method to find the right most node in a subtree
    /// (should have the largest value)
    /// </summary>
    private Node FindMax(Node node)
    {
        while (node.right != null) node = node.right;
        return node;
    }

    /// <summary>
    /// Recursive method that traverses the entire BST
    /// Essentially, it's a DFS.
    /// Preorder prints before the recursive calls.
    /// </summary>
    private void PreorderTraversal(Node node)
    {
        // Handle case where we've reached the bottom of
        // the BST
        if (node == null) return;
        Console.Write($"{node.data}, ");
        PreorderTraversal(node.left);
        PreorderTraversal(node.right);
    }

    /// <summary>
    /// Recursive method that traverses the entire BST.
    /// Essentially, it's a DFS.
    /// Postorder prints after the recursive calls.
    /// </summary>
    private void PostorderTraversal(Node node)
    {
        // Handle case where we've reached the bottom of
        // the BST
        if (node == null) return;
        PostorderTraversal(node.left);
        PostorderTraversal(node.right);
        Console.Write($"{node.data}, ");
    }

    /// <summary>
    /// Recursive method that traverses the entire BST.
    /// Essentially, it's a DFS.
    /// Inorder prints inbetween the recursive calls.
    /// </summary>
    /// <param name="node"></param>
    private void InorderTraversal(Node node)
    {
        // Handle case where we've reached the bottom of
        // the BST
        if (node == null) return;
        InorderTraversal(node.left);
        Console.Write($"{node.data}, ");
        InorderTraversal(node.right);
    }

    /// <summary>
    /// Iterative method that traverses the entire BST, layer by layer.
    /// Essentially, it's a BFS.
    /// Because it's BFS, it has to utilize a Queue DT.
    /// </summary>
    /// <param name="node"></param>
    private void LevelorderTraversal(Node node)
    {
        // The queue where we will store our nodes
        Queue<Node> nodeQueue = new Queue<Node>();

        // Enqueue the first node
        nodeQueue.Enqueue(node);

        // We continue to iterate as long as there's items
        // in the queue
        while (nodeQueue.Count > 0)
        {
            // We dequeue a node, and get a reference to it for printing
            Node tempNode = nodeQueue.Dequeue();

            // We enqueue the current nodes left and right child nodes
            // for dequeueing later
            if (tempNode.left != null) nodeQueue.Enqueue(tempNode.left);
            if (tempNode.right != null) nodeQueue.Enqueue(tempNode.right);

            Console.Write($"{tempNode.data}, ");
        }
    }

    /// <summary>
    /// Pre order traversal is essentially Depth First Search.
    /// The difference is that pre order prints BEFORE the recursive calls
    /// </summary>
    public void Preorder()
    {
        PreorderTraversal(root);
    }

    /// <summary>
    /// Post order traversal is essentially Depth First Search.
    /// The difference is that post order prints AFTER the recursive calls
    /// </summary>
    public void Postorder()
    {
        PostorderTraversal(root);
    }

    /// <summary>
    /// In order traversal is essentially Depth First Search.
    /// The difference is that in order prints BETWEEN the recursive calls.
    /// This produces the data being printed in order (from smallest to largest)
    /// </summary>
    public void Inorder()
    {
        InorderTraversal(root);
    }

    /// <summary>
    /// Level order traversal is essentially Breadth First Search.
    /// It traverses the BST layer by layer.
    /// </summary>
    public void Levelorder()
    {
        LevelorderTraversal(root);
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
        Console.WriteLine();

        Console.WriteLine($"Remove 3: {bst.Remove(3)}");
        Console.WriteLine($"Remove 6: {bst.Remove(6)}");
        Console.WriteLine($"Remove 5: {bst.Remove(5)}");
        Console.WriteLine($"Contains 3: {bst.Contains(3)}");
        Console.WriteLine($"Contains 5: {bst.Contains(5)}");
        Console.WriteLine();

        Console.WriteLine($"Size: {bst.Size()}");
        Console.WriteLine($"Empty?: {bst.IsEmpty()}");
        Console.WriteLine();

        Console.WriteLine($"Add 3: {bst.Add(3)}");
        Console.WriteLine($"Add 6: {bst.Add(6)}");
        Console.WriteLine($"Add 5: {bst.Add(5)}");
        Console.WriteLine();

        Console.WriteLine($"Postorder traversal: ");
        bst.Postorder();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine($"Preorder traversal: ");
        bst.Preorder();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine($"Inorder traversal: ");
        bst.Inorder();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine($"Levelorder traversal: ");
        bst.Levelorder();
        Console.WriteLine();
        Console.WriteLine();
    }
}
