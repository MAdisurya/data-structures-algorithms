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

        // Make sure we set the head and tail to null as well
        head = null;
        tail = null;
        // Make sure to reset the size
        size = 0;
    }

    /// <summary>
    /// Adds a node to the head of the LinkedList
    /// /// Time Complexity: O(1)
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
    /// Time Complexity: O(1)
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
        if (IsEmpty()) throw new Exception("First(): LinkedList is empty!");

        return head.data;
    }

    /// <summary>
    /// Returns the data of the last node (tail) of the Linked List.
    /// Time Complexity: O(1)
    /// </summary>
    public T Last()
    {
        // First we need to handle if linked list is empty
        if (IsEmpty()) throw new Exception("Last(): LinkedList is empty!");

        return tail.data;
    }

    /// <summary>
    /// Helper method for removing the head node from the LinkedList
    /// </summary>
    private void RemoveFirst()
    {

    }

    /// <summary>
    /// Helper moethod for removing the tail node from the LinkedList
    /// </summary>
    private void RemoveLast()
    {

    }

    /// <summary>
    /// Helper method for removing a node from the LinkedList
    /// </summary>
    private void Remove(Node node)
    {
        
    }

    /// <summary>
    /// Removes the node in the LinkedList with the passed data/value.
    /// </summary>
    //public void Remove(T data)
    //{
    //    // Get a reference to the head node to start traversing.
    //    Node node = head;

    //    while (node != null)
    //    {
    //        if (node.data.ToString() == data.ToString())
    //        {
    //            // We want to set this nodes previous node to point to
    //            // this nodes next node
    //            // Essentially, over this node
    //            node.prev.next = node.next;
    //            // We also want to set this nodes next node to point to
    //            // this nodes previous node
    //            node.next.prev = node.prev;

    //            // Then we remove and clean up memory for this node
    //            node.data = default;
    //            node.next = null;
    //            node.prev = null;
    //            node = null;
    //        }
    //        else
    //        {
    //            // Otherwise, we move on to the next node
    //            node = node.next;
    //        }
    //    }

    //    // Here we throw an exception because we traversed through the LinkedList
    //    // and couldn't find any node with the associated data
    //    throw new Exception($"Node with data: {data} doesn't exist in the LinkedList!");
    //}

    /// <summary>
    /// Removes a node at the given index.
    /// Time Complexity: O(n)
    /// </summary>
    public void RemoveAt(int index = 0)
    {
        // Handle edge case where index >= size - 1 or index < 0
        if (index < 0 || index >= size - 1) throw new ArgumentException();

        // Get reference to head to start traversing the LinkedList
        Node node = head;

        for (int i = 0; i < index; i++)
        {
            node = node.next;
        }

        // Need to implement Remove(Node node) first for this to work
        Remove(node);
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

    /// <summary>
    /// Time Complexity: O(n)
    /// </summary>
    public void Clear()
    {
        // Get a reference to the head, and start traversing the LinkedList from there
        Node node = head;

        while (node != null)
        {
            Node next = node.next;
            node.next = null;
            node.data = default;
            node = next;
        }

        // Make sure we set the head and tail to null as well
        head = null;
        // Make sure to reset the size
        size = 0;
    }

    public void Add(T data)
    {
        // If LinkedList is empty, we create a new node and store a reference to it in head
        if (IsEmpty())
        {
            head = new Node(data, null);
        }
        else
        {
            // Create a new node and set the next reference to the head
            Node node = new Node(data, head);
            // Then we assign the newly created node as the new head
            head = node;
        }

        size++;
    }

    /// <summary>
    /// This method is to show the difference in Time Complexity
    /// against a LinkedList that has a tail reference (See the DoublyLinkedList implementation)
    /// and one that doesn't.
    /// In this case, no tail - so Time Complexity is O(n).
    /// </summary>
    public void AddLast(T data)
    {
        if (IsEmpty())
        {
            // If empty, we add a new head node
            head = new Node(data, null);
        }
        else
        {
            // Otherwise we traverse the LinkedList until we find the last node
            // Get a reference to the head
            Node node = head;

            while (node.next != null)
            {
                node = node.next;
            }

            // Here we know that the next node is null - meaning it's the last node
            // So create a new node and assign it to node.next
            node.next = new Node(data, null);
        }

        size++;
    }

    public T First()
    {
        // First we need to handle if linked list is empty
        if (IsEmpty()) throw new Exception("First(): LinkedList is empty!");

        return head.data;
    }

    /// <summary>
    /// This method is to show the difference in Time Complexity
    /// against a LinkedList that has a tail reference (See the DoublyLinkedList implementation)
    /// and one that doesn't.
    /// In this case, no tail - so Time Complexity is O(n).
    /// </summary>
    /// <returns></returns>
    public T Last()
    {
        // First we need to handle if linked list is empty
        if (IsEmpty()) throw new Exception("First(): LinkedList is empty!");

        // Get a reference to the head for traversing the LinkedList
        Node node = head;

        while (node.next != null)
        {
            node = node.next;
        }

        // Here we know that we're at the last node so return its data
        return node.data;
    }

    private void Remove(Node node)
    {
        
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
        DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
        SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();

        Console.WriteLine($"DoublyLinkedList.IsEmpty() == {doublyLinkedList.IsEmpty()}");

        doublyLinkedList.AddFirst(5);
        doublyLinkedList.AddFirst(20);
        doublyLinkedList.AddLast(25);
        doublyLinkedList.AddLast(41);

        Console.WriteLine($"DoublyLinkedList.First() == {doublyLinkedList.First()}");
        Console.WriteLine($"DoublyLinkedList.Last() == {doublyLinkedList.Last()}");
        Console.WriteLine($"DoublyLinkedList.Size() == {doublyLinkedList.Size()}");
        Console.WriteLine($"DoublyLinkedList.IsEmpty() == {doublyLinkedList.IsEmpty()}");

        // Output
        // ----------------
        // True
        // 20
        // 41
        // 4
        // False

        Console.WriteLine("");

        Console.WriteLine($"SinglyLinkedList.IsEmpty() == {singlyLinkedList.IsEmpty()}");

        singlyLinkedList.Add(2);
        singlyLinkedList.Add(9);
        singlyLinkedList.AddLast(21);
        singlyLinkedList.AddLast(35);

        Console.WriteLine($"SinglyLinkedList.First() == {singlyLinkedList.First()}");
        Console.WriteLine($"SinglyLinkedList.Last() == {singlyLinkedList.Last()}");
        Console.WriteLine($"SinglyLinkedList.Size() == {singlyLinkedList.Size()}");
        Console.WriteLine($"SinglyLinkedList.IsEmpty() == {singlyLinkedList.IsEmpty()}");

        // Output
        // ----------------
        // True
        // 9
        // 35
        // 4
        // False
    }
}
