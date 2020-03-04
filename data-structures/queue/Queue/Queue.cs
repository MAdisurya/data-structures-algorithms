using System;

/// <summary>
/// Queue data structure implemented using a Doubly Linked List
/// </summary>
class QueueLinkedList<T>
{
    /// <summary>
    /// Internal Node class
    /// </summary>
    private class Node
    {
        // The data associated with the node
        public T data;
        // Reference to the next node
        public Node next;
        // Reference to the previous node
        public Node prev;

        public Node(T data = default, Node next = null, Node prev = null)
        {
            this.data = data;
            this.next = next;
            this.prev = prev;
        }
    }

    // Reference to the head of the Linked List
    private Node head = null;
    // Reference to the tail of the Linked List
    private Node tail = null;

    // The size of the Queue
    private int size = 0;

    /// <summary>
    /// Returns the size of the queue
    /// </summary>
    public int Size()
    {
        return size;
    }

    /// <summary>
    /// Checks whether the queue is empty
    /// and returns either true or false
    /// </summary>
    public bool IsEmpty()
    {
        return size == 0;
    }

    /// <summary>
    /// Inserts a new item at the tail/back of the queue.
    /// Time Complexity: O(1)
    /// </summary>
    /// <param name="data"></param>
    public void Enqueue(T data)
    {
        // If queue is empty, we create a new node
        // and assign it to the head and tail
        if (IsEmpty())
        {
            Node node = new Node(data, null, null);
            head = node;
            tail = node;
        }
        else
        {
            // We assign the prev reference to the tail
            Node node = new Node(data, null, tail);
            // Update the tails next referece to the new node
            tail.next = node;
            // Then we update the tail reference to point
            // to the new node
            tail = node;

        }

        Console.WriteLine($"Enqueue(): {data.ToString()}");

        size++;
    }

    /// <summary>
    /// Removes the item at the head/front of the queue.
    /// Time Complexity: O(1)
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
        // Handle edge case where queue is empty
        if (IsEmpty()) throw new Exception("Queue is empty!");
        // Handle the case where there's only one item in the queue
        if (Size() == 1) tail = null;

        // The data we'll return
        T data = head.data;
        // Reference to the heads next node
        Node nextNode = head.next;

        // Make sure to delete references, data, etc to avoid
        // Memory leaks
        head.next = null;
        head.prev = null;
        head.data = default;
        // Also need to update the new head to
        // the next node if there is one
        head = nextNode;

        size--;

        return data;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        QueueLinkedList<int> queue = new QueueLinkedList<int>();

        Console.WriteLine($"Size(): {queue.Size()}");
        Console.WriteLine($"IsEmpty(): {queue.IsEmpty()}");
        Console.WriteLine();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);

        Console.WriteLine($"Size(): {queue.Size()}");
        Console.WriteLine($"IsEmpty(): {queue.IsEmpty()}");
        Console.WriteLine();

        Console.WriteLine($"Dequeue(): {queue.Dequeue().ToString()}");
        Console.WriteLine($"Dequeue(): {queue.Dequeue().ToString()}");
        Console.WriteLine();

        Console.WriteLine($"Size(): {queue.Size()}");

        // Expected Output:
        // ------------------
        // Size(): 0
        // IsEmpty(): True
        //
        // Enqueue(): 10
        // Enqueue(): 20
        // Enqueue(): 30
        // Enqueue(): 40
        //
        // Size(): 4
        // IsEmpty(): False
        //
        // Dequeue(): 10
        // Dequeue(): 20
        //
        // Size(): 2
    }
}
