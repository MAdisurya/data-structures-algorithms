using System;

public class StackLinkedList<T>
{
    /// <summary>
    /// Internal node class for linked list implementation in stack
    /// </summary>
    private class Node
    {
        public T data;
        public Node next;

        public Node(T data = default, Node next = null)
        {
            this.data = data;
            this.next = next;
        }
    }

    // Reference to the head node of the linked list
    private Node head = null;
    // Variable to keep track of the size of the stack
    private int size = 0;

    /// <summary>
    /// Returns the size of the stack
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return size;
    }

    /// <summary>
    /// Returns whether the stack is empty or not
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return size == 0;
    }

    /// <summary>
    /// Adds a node/item to the stack.
    /// Here we're following the FILO ordering, so push to the bottom/head
    /// of the stack.
    /// </summary>
    public void Push(T data)
    {
        // Handle edge case where stack is empty
        // Basically, just make a new node and assign reference of it to head
        if (IsEmpty())
        {
            Node node = new Node(data, null);
            head = node;
        }
        // Otherwise if stack is not empty, we make sure that our newly
        // created Nodes next pointer points to the head
        else
        {
            Node node = new Node(data, head);
            // Assign node as the new head
            head = node;
        }

        // Increment the size
        size++;

        Console.WriteLine($"Push: {head.data.ToString()}");
    }

    /// <summary>
    /// Removes a node/item from the stack and returns the node.data.
    /// Here we're following the FILO ordering, so pop from the bottom/head
    /// of the stack.
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        // Handle case where stack is empty
        if (IsEmpty()) throw new Exception("Stack is empty!");

        // Get a reference to the head.data for returning
        Node node = head;
        T data = node.data;
        // Assign the head to it's next pointer
        head = head.next;

        // We need to remove the node from memory to avoid memory leak
        node.data = default;
        node.next = null;

        // Decrement the size
        size--;

        return data;
    }

    /// <summary>
    /// Returns the top element of the stack (in this case, the bottom)
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        return head.data;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        StackLinkedList<string> stackLinkedList = new StackLinkedList<string>();

        Console.WriteLine($"Size: {stackLinkedList.Size()}");
        Console.WriteLine($"IsEmpty: {stackLinkedList.IsEmpty()}");

        Console.WriteLine();

        stackLinkedList.Push("John");
        stackLinkedList.Push("Sarah");
        stackLinkedList.Push("Mario");

        Console.WriteLine();

        Console.WriteLine($"Size: {stackLinkedList.Size()}");
        Console.WriteLine($"IsEmpty: {stackLinkedList.IsEmpty()}");

        Console.WriteLine();

        Console.WriteLine($"Pop: {stackLinkedList.Pop().ToString()}");
        Console.WriteLine($"Peek: {stackLinkedList.Peek().ToString()}");
        Console.WriteLine($"Pop: {stackLinkedList.Pop().ToString()}");
        Console.WriteLine($"Peek: {stackLinkedList.Peek().ToString()}");

        Console.WriteLine();

        Console.WriteLine($"Size: {stackLinkedList.Size()}");

        // Expected Output
        // ------------------
        // Size: 0
        // IsEmpty: True
        //
        // Push: John
        // Push: Sarah
        // Push: Mario
        //
        // Size: 3
        // IsEmpty: False
        //
        // Pop: Mario
        // Peek: Sarah
        // Pop: Sarah
        // Peek: John
        //
        // Size: 1
    }
}
