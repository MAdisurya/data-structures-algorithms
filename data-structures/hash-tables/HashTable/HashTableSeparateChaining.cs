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

            return index;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

}