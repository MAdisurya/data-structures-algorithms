using System;
using System.Collections.Generic;

public class AVLTree<T> where T : IComparable
{
    // Internal Node class
    private class Node
    {
        // Balance Factor of the node
        public int balanceFactor;
        // The height of this node in the tree
        public int height;
        // The value associated with the node
        public T value;
        // References to left and right child nodes
        public Node left, right;

        public Node(T value = default, Node left = null, Node right = null)
        {
            this.value = value;
            this.left = left;
            this.right = right;

            height = 0;
            balanceFactor = 0;
        }

        public string GetValue()
        {
            return value.ToString();
        }
    }

    // Reference to root node in the tree
    private Node root;

    private int nodeCount = 0;

    /// <summary>
    /// Returns the height of the tree.
    /// "The height of the tree is the number of edges between the tree's root
    /// and it's furtest leaf node. This means that a tree containing a
    /// single node has a height of 0." - William Fiset
    /// </summary>
    public int Height()
    {
        if (root == null) return 0;
        return root.height;
    }

    /// <summary>
    /// Returns the size of the tree
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return nodeCount;
    }

    /// <summary>
    /// Returns whether the tree is empty or not.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return Size() == 0;
    }

    /// <summary>
    /// Recursive helper method that checks whether the passed
    /// node with passed value exists in the tree.
    /// </summary>
    private bool Contains(Node node, T value)
    {
        // Handle case where passed node is null
        if (node == null) return false;

        // Compare the passed value and node value
        int compare = value.CompareTo(node.value);

        // If the value is less than node.value, we dig into the left subtree
        if (compare < 0) return Contains(node.left, value);

        // Otherwise, dig into the right subtree
        if (compare > 0) return Contains(node.right, value);

        return true;
    }

    /// <summary>
    /// Returns whether a node with the passed value exists
    /// in the tree.
    /// </summary>
    public bool Contains(T value)
    {
        return Contains(root, value);
    }

    /// <summary>
    /// Updates the passed node's height and balance factor
    /// </summary>
    /// <param name="node"></param>
    private void Update(Node node)
    {
        // Get a reference to the height of both the left and right branches
        // If child node is null, then we -1 because we will +1 later.
        int leftNodeHeight = (node.left == null) ? -1 : node.left.height;
        int rightNodeHeight = (node.right == null) ? -1 : node.right.height;

        // Update this node's height
        // The height is the distance between this current node, and it's
        // furthest leaf node.
        node.height = 1 + Math.Max(leftNodeHeight, rightNodeHeight);

        // Update the balance factor
        node.balanceFactor = rightNodeHeight - leftNodeHeight;
    }

    /// <summary>
    /// Helper method for balancing the tree when the passed node's
    /// balance factor is +2 or -2.
    /// </summary>
    private Node Balance(Node node)
    {
        // If left heavy tree
        if (node.balanceFactor < -1)
        {
            // Left Left Case
            if (node.left.balanceFactor <= 0)
            {
                return LeftLeftCase(node);
            }
            // Left Right Case
            else
            {
                return LeftRightCase(node);
            }
        }
        // Right heavy tree
        else if (node.balanceFactor > 1)
        {
            // Right Right Case
            if (node.right.balanceFactor >= 0)
            {
                return RightRightCase(node);
            }
            // Right Left Case
            else
            {
                return RightLeftCase(node);
            }
        }

        return node;
    }

    /// <summary>
    /// Helper method that inserts the passed node into the tree.
    /// </summary>
    private Node Insert(Node node, T value)
    {
        // Handle base case for inserting node in recursive call
        if (node == null) return new Node(value);

        // We need to recursively traverse the tree to find where we
        // should insert the new node.

        // Compare the passed value with node.value
        int compare = value.CompareTo(node.value);

        // If value is less than node.value, we dig the left subtree
        if (compare < 0)
        {
            node.left = Insert(node.left, value);
        }
        // Otherwise, dig the right subtree
        else
        {
            node.right = Insert(node.right, value);
        }

        // Update the nodes balance factor and height values
        Update(node);

        // Re-balance the tree
        return Balance(node);
    }

    /// <summary>
    /// Creates a new node and inserts the passed value into the tree.
    /// </summary>
    public void Insert(T value)
    {
        if (value == null) return;

        if (!Contains(root, value))
        {
            root = Insert(root, value);
            nodeCount++;
        }

        Console.WriteLine($"Inserted Node: {value}");
    }

    /// <summary>
    /// Perform a left rotation on the tree
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private Node LeftRotation(Node node)
    {
        // Store reference to current nodes right child (B)
        Node newParent = node.right;
        // Assign the current nodes right child to B's left child
        node.right = newParent.left;
        // Assign B's left child to the current node
        newParent.left = node;

        // Update the balance factor and height of A and B
        Update(node);
        Update(newParent);

        return newParent;
    }

    /// <summary>
    /// Perform a right rotation on the tree
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private Node RightRotation(Node node)
    {
        // Store reference to current nodes left child (B)
        Node newParent = node.left;
        // Assign the current nodes left child to B's right child
        node.left = newParent.right;
        // Assign B's right child to the current node
        newParent.right = node;

        // Update the balance factor and height of A and B
        Update(node);
        Update(newParent);

        return newParent;
    }

    private Node LeftLeftCase(Node node)
    {
        return RightRotation(node);
    }

    private Node LeftRightCase(Node node)
    {
        node.left = LeftRotation(node.left);
        return LeftLeftCase(node);
    }

    private Node RightRightCase(Node node)
    {
        return LeftRotation(node);
    }

    private Node RightLeftCase(Node node)
    {
        node.right = RightRotation(node.right);
        return RightRightCase(node);
    }

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

            Console.Write($"{tempNode.value}, ");
        }
    }

    public void Levelorder()
    {
        LevelorderTraversal(root);
    }
}

public class MainClass
{
    public static void Main()
    {
        AVLTree<int> avl = new AVLTree<int>();

        Console.WriteLine("AVL Tree");
        Console.WriteLine("-----------------");
        Console.WriteLine();

        Console.WriteLine($"Size(): {avl.Size()}");
        Console.WriteLine($"IsEmpty(): {avl.IsEmpty()}");
        Console.WriteLine();

        avl.Insert(8);
        avl.Insert(5);
        avl.Insert(14);
        avl.Insert(4);
        avl.Insert(6);
        avl.Insert(12);
        avl.Insert(16);
        avl.Insert(3);
        avl.Insert(10);
        avl.Insert(2);
        avl.Insert(9);
        Console.WriteLine();

        Console.WriteLine($"Size(): {avl.Size()}");
        Console.WriteLine($"IsEmpty(): {avl.IsEmpty()}");
        Console.WriteLine();

        Console.WriteLine("Before Balancing: 8, 5, 14, 4, 6, 12, 16, 3, 10, 2, 9");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("After Balancing: ");
        avl.Levelorder();
        Console.WriteLine();
        Console.WriteLine();

        // Expected Output:
        // -----------------
        // Size(): 0
        // IsEmpty(): True
        //
        // Inserted Node: 8
        // Inserted Node: 5
        // Inserted Node: 14
        // Inserted Node: 4
        // Inserted Node: 6
        // Inserted Node: 12
        // Inserted Node: 16
        // Inserted Node: 3
        // Inserted Node: 10
        // Inserted Node: 2
        // Inserted Node: 9
        //
        // Size(): 11
        // IsEmpty(): False
        //
        // Before Balancing: 8, 5, 14, 4, 6, 12, 16, 3, 10, 2, 9
        //
        // After Balancing: 8, 5, 14, 3, 6, 10, 16, 2, 4, 9, 12
    }
}