/**
 * LinkedList C# implementation written by Mario Adisurya
 * Feel free to fork it from my GitHub - https://github.com/MAdisurya/data-structures-algorithms
 */

using System;

public class DoublyLinkedList<T> where T : IComparable
{
    /// <summary>
    /// Node class that represents the Linked List Node
    /// Each Node should contain data, and a reference to the next/prev Node
    /// in a DoublyLinkedList
    /// </summary>
    private class Node
    {
        // The data associated with the node
        public T data;
        // Reference to the next/previous nodes
        public Node prev;
        public Node next;

        public Node(T data, Node next = null, Node prev = null)
        {
            this.data = data;
            this.next = next;
            this.prev = prev;
        }
    }

    // Variable to store the size of the Linked List
    private int size = 0;
    // Reference for the head node
    private Node head = null;
    // Reference for the tail node (not always necessarily needed in LinkedList implementations)
    private Node tail = null;

    /// <summary>
    /// Returns the size of the Linked List
    /// </summary>
    public int Size()
    {
        return size;
    }

    /// <summary>
    /// Returns true if LinkedList is empty
    /// </summary>
    public bool IsEmpty()
    {
        return size == 0;
    }

    /// <summary>
    /// Empties the Linked List.
    /// We need to make sure we set all the nodes to null
    /// to avoid memory leaks.
    /// Time Complexity: O(n)
    /// </summary>
    public void Clear()
    {
        // Get a reference to the head, and start traversing the LinkedList from there
        Node node = head;

        while (node != null)
        {
            Node next = node.next;
            node.prev = null;
            node.next = null;
            node.data = default;
            node = next;
        }
    }

    /// <summary>
    /// Adds a node to the head of the LinkedList
    /// </summary>
    public void AddFirst(T data)
    {
        // If LinkedList is empty, we create a new node and store a reference to it in head and tail
        if (IsEmpty())
        {
            head = new Node(data, null, null);
            tail = head;
        }
        else
        {
            // Create a new node and set the next reference to the head
            // Then assign the current head nodes previous reference to the new node
            head.prev = new Node(data, head, null);
            // Then we assign the newly created node as the new head
            head = head.prev;
        }

        size++;
    }

    /// <summary>
    /// Adds a node to the tail of the LinkedList
    /// </summary>
    public void AddLast(T data)
    {
        // If LinkedList is empty, we create a new node and store a reference to it in the head and tail
        if (IsEmpty())
        {
            head = new Node(data, null, null);
            tail = head;
        }
        else
        {
            // Create a new node and set the previous reference to the tail
            // Then assign the current tail nodes next reference to the new node
            tail.next = new Node(data, null, tail);
            // Then we assign the newly created node as the new tail
            tail = tail.next;
        }

        size++;
    }

    /// <summary>
    /// Returns the data of the first node (head) of the Linked List.
    /// Time Complexity: O(1)
    /// </summary>
    public T First()
    {
        // First we need to handle if linked list is empty
        if (IsEmpty()) throw new Exception("LinkedList is empty!");

        return head.data;
    }

    /// <summary>
    /// Returns the data of the last node (tail) of the Linked List.
    /// Time Complexity: O(1)
    /// </summary>
    public T Last()
    {
        // First we need to handle if linked list is empty
        if (IsEmpty()) throw new Exception("LinkedList is empty!");

        return tail.data;
    }

    public void Remove(T data)
    {

    }

    public void RemoveAt(int index)
    {

    }

    public bool Contains(T data)
    {
        return false;
    }
}

public class SinglyLinkedList<T> where T : IComparable
{
    /// <summary>
    /// Node class that represents the Linked List Node
    /// Each Node should contain data, and a reference to the next Node
    /// in a SinglyLinkedList
    /// </summary>
    private class Node
    {
        // The data associated with the node
        public T data;
        // Reference to the next node in the LinkedList
        public Node next;

        public Node(T data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }

    // Variable to store the size of the LinkedList
    private int size = 0;
    // Reference to the node at the head of the Linked List
    private Node head = null;

    /// <summary>
    /// Returns the size of the Linked List
    /// </summary>
    public int Size()
    {
        return size;
    }

    /// <summary>
    /// Returns true if LinkedList is empty
    /// </summary>
    public bool IsEmpty()
    {
        return size == 0;
    }

    public void Clear()
    {

    }

    public void Add()
    {

    }

    public void AddLast()
    {

    }

    public T First()
    {
        return default;
    }

    public T Last()
    {
        return default;
    }

    public void Remove(T data)
    {

    }

    public void RemoveAt(int index)
    {

    }

    public bool Contains(T data)
    {
        return false;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}
