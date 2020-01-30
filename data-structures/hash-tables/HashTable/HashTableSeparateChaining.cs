/**
 * HashTable C# implementation written by Mario Adisurya
 * Feel free to fork it from my GitHub - https://github.com/MAdisurya/data-structures-algorithms
 */

using System;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    ///     Class definition of Nodes for the Linked List.
    ///     Since we're doing Separate Chaning, each entry
    ///     inside the Array will be a reference to a Node
    ///     in the Linked List.
    /// </summary>
    /// <typeparam name="K">The Key for the Node</typeparam>
    /// <typeparam name="V">The Value for the Node</typeparam>
    class HashNode<K, V> where K : IComparable<K>
    {
        // Junk initialize key and value variables
        public K key;
        public V value;

        // Reference to the next node
        public HashNode<K, V> next;

        // Constructor
        public HashNode(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }

    /// <summary>
    ///     Class definition to represent the entire Hash Table.
    ///     This class will manage the Hash Table, adding, removing,
    ///     look-up, etc.
    /// </summary>
    /// <typeparam name="K">The Key for the Node</typeparam>
    /// <typeparam name="V">The Value for the Node</typeparam>
    class HashTable<K, V> where K : IComparable<K>
    {
        // Initialize the array where we will store our Linked Lists / Buckets
        private List<HashNode<K, V>> m_BucketArray;

        // The current capacity of the array
        // Necessary to know if we need to rehash and rebuild the Hash Table
        private int m_NumBuckets;

        // Current size of the Array List
        private int m_Size;

        // Constructor to initialize the above variables
        public HashTable()
        {
            m_BucketArray = new List<HashNode<K, V>>();
            m_NumBuckets = 10;
            m_Size = 0;

            // Fill the bucket array to occupy memory space
            // To meet the m_NumBuckets amount
            for (int i = 0; i < m_NumBuckets; i++)
            {
                m_BucketArray.Add(null);
            }
        }

        /// <summary>
        /// Returns the size of the Hash Table
        /// </summary>
        public int Size()
        {
            return m_Size;
        }

        /// <summary>
        /// Returns a boolean for if the Hash Table is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return m_Size == 0;
        }

        /// <summary>
        /// The Hash Function that converts a key into an index to use for the Array
        /// </summary>
        /// <param name="key">The key to convert</param>
        private int GetKeyIndex(K key)
        {
            // Here we'll use the built in GetHashCode() method to hash the key
            int hashCode = key.GetHashCode();
            // Then we'll modulo by the number of buckets to make sure
            // That the index stays witin [0, m_NumBuckets] range
            int index = hashCode % m_NumBuckets;
            // If index resolves to a negative num, make it positive
            if (index < 0) index *= -1;

            return index;
        }

        /// <summary>
        /// Removes the node at the given index generated from the Key
        /// </summary>
        /// <param name="key">The Key associated with the value</param>
        public V Remove(K key)
        {
            // Apply Hash Function to get the index from the key
            int bucketIndex = GetKeyIndex(key);

            // Get the head of the Linked List
            HashNode<K, V> head = m_BucketArray[bucketIndex];
            // We need something to keep track of the previous node
            HashNode<K, V> prev = null;

            // Perform a linear search to find the node with the same key
            // We'll use an iterative approach here
            while (head != null) // We keep looping until we've checked through all the nodes
            {
                // If we found the key, exit the loop
                if (head.key.Equals(key))
                {
                    break;
                }

                prev = head;
                head = head.next;
            }

            // If key wasn't found in any node, we return
            if (head == null)
            {
                return default;
            }

            // Reduce the size counter
            m_Size--;

            // Remove the key
            // If the head node isn't being removed
            if (prev != null)
            {
                prev.next = head.next;
            }
            // Handle condition where we remove the head node
            else
            {
                m_BucketArray[bucketIndex] = head.next;
            }

            return head.value;
        }

        /// <summary>
        /// Look-up method which returns the value from the given node at index
        /// generated from the key.
        /// </summary>
        /// <param name="key">The Key associated with the value</param>
        public V Get(K key)
        {
            // Apply Hash Function to find the index for the key
            int bucketIndex = GetKeyIndex(key);

            // Get the head of the Linked List
            HashNode<K, V> head = m_BucketArray[bucketIndex];

            // We do a linear search through the Linked List to find
            // the Node with the same key
            // We'll do this using an iterative approach
            while (head != null) // Keep looping until we've checked thorugh all the Nodes
            {
                // If we find the Node, return
                if (head.key.Equals(key))
                {
                    return head.value;
                }

                // Otherwise, we move on to the next Node
                head = head.next;
            }

            // If the key isn't found, we return
            return default;
        }

        /// <summary>
        /// Adds a key, value pair entry into the Hash Table.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            // Apply Hash Function to find the index for the key
            int bucketIndex = GetKeyIndex(key);

            // Get the head of the Linked List
            HashNode<K, V> head = m_BucketArray[bucketIndex];

            // Check if the key is already present by going through the Linked List
            // We'll do this using an iterative approach
            while (head != null) // Keep looping until we've checked through all the Nodes
            {
                // If we find a Node with the same key, update the value
                if (head.key.Equals(key))
                {
                    head.value = value;
                    return;
                }

                // Otherwise, we move on to the next node
                head = head.next;
            }

            // If the key isn't already in the Hash Table, then
            // we insert a new node as the head of the Linked List

            // We re-assign head to make sure we're referencing the right head Node
            head = m_BucketArray[bucketIndex];
            // Instantiate a new HashNode
            HashNode<K, V> newNode = new HashNode<K, V>(key, value);
            // Assign newNodes next pointer to refer to the current head
            newNode.next = head;
            // Then we set newNode as the new head
            m_BucketArray[bucketIndex] = newNode;

            // Don't forget to increment the size counter
            m_Size++;

            // If load factor goes beyond the threshold, then
            // Double hash table size, and rehash
            if ((m_Size / m_NumBuckets) >= 0.7)
            {
                // We'll instantiate a new array to hold the prev array
                List<HashNode<K, V>> temp = m_BucketArray;
                // Then instantiate a new array for m_BucketArray
                m_BucketArray = new List<HashNode<K, V>>();
                // Double the size of m_NumBuckets
                m_NumBuckets *= 2;
                // Reset the size counter, which will get incremented when
                // We add the nodes back into the array
                m_Size = 0;

                // First make sure to fill the array
                // So the size is == to m_NumBuckets
                for (int i = 0; i < m_NumBuckets; i++)
                {
                    m_BucketArray.Add(null);
                }

                // Then add all the Nodes back into the new array
                foreach (HashNode<K, V> node in temp)
                {
                    HashNode<K, V> headNode = node;

                    while (headNode != null) // We go through each Node inside each Linked List
                    {
                        Add(headNode.key, headNode.value);
                        headNode = headNode.next;
                    }
                }
            }
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            HashTable<string, string> map = new HashTable<string, string>();

            map.Add("Mario", "This is Mario");
            map.Add("John", "This is John");
            map.Add("Smith", "This is Smith");
            map.Add("George", "This is George");
            map.Add("Luigi", "This is Luigi");

            Console.WriteLine(map.Size());
            Console.WriteLine(map.IsEmpty());

            Console.WriteLine(map.Get("Mario"));
            Console.WriteLine(map.Get("Luigi"));

            Console.WriteLine(map.Remove("John"));
            Console.WriteLine(map.Size());

            // Output:
            // 5
            // False
            // This is Mario
            // This is Luigi
            // This is John
            // 4
        }
    }

}