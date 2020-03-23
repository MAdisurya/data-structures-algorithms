using System;
using System.Collections.Generic;

public class Trie
{
    private class Node
    {
        public bool isEndOfWord;
        public Dictionary<char, Node> children = new Dictionary<char, Node>();

        public Node()
        {
            isEndOfWord = false;
        }

        public void AddChild(Node node, char _character)
        {
            children.Add(_character, node);
        }
    }

    private Node root = new Node();

    /// <summary>
    /// Inserts a word into the trie.
    /// This method will iterate through each character in the
    /// key, and insert the char if it doesn't exist in the trie
    /// </summary>
    public void Insert(string word)
    {
        // Get a reference to the root node for traversing
        Node node = root;
        bool isPrefix = false;

        if (word.Length <= 0) throw new ArgumentException("Word parameter cannot be an empty string!");

        // Iterate through the word, and process each char
        // one at a time
        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];

            // If the character doesn't exist in children
            // then create a new node and append it to the
            // current nodes children
            if (!node.children.ContainsKey(ch))
            {
                Node nextNode = new Node();
                node.AddChild(nextNode, ch);
            }

            // We keep traversing the trie as long as
            // there are still characters in the word
            node = node.children[ch];
        }

        // If the current node is already an end of word
        if (node.isEndOfWord) isPrefix = true;
        // If the current node is not the root, we know we can set
        // it as an end of word
        if (node != root) node.isEndOfWord = true;

        if (isPrefix)
        {
            Console.WriteLine($"Already exists in the Trie: {word}"); 
        }
        else
        {
            Console.WriteLine($"Successfully inserted word: {word}");
        }
    }

    /// <summary>
    /// Searches the trie for the passed word.
    /// Will return true if it exists, false if it doesn't.
    /// </summary>
    public bool Contains(string word)
    {
        // Get a reference the the root node for traversing
        Node node = root;

        if (word.Length <= 0) throw new ArgumentException("Word parameter cannot be an empty string!");

        // Traverse the trie until we reach the bottom or stop
        // because the word doesn't exist
        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];
            // if the node is null, we return false
            if (!node.children.ContainsKey(ch)) return false;
            // Assign node to refer to the next node (child node)
            node = node.children[ch];
        }

        // We need to do one final check because of how
        // the logic is layered
        if (node != null) return true;

        return false;
    }

    /// <summary>
    /// Helper method that removes/deletes all references to an
    /// array of nodes - to help the GC and avoid memory leaks.
    /// </summary>
    /// <param name="parents"></param>
    private void Remove(Node[] nodes)
    {
        // Iterate the nodes array in reverse
        // To make sure we don't delete an existing word.
        // use i > 0 as the second argument
        // to make sure it doesn't set the starting char node
        // to null
        // e.g. "Card", all nodes will be removed
        // but root.children will still have key: "C", but value will
        // be null - we want to avoid that.
        for (int i = nodes.Length - 1; i > 0; i--)
        {
            // If we find that there is an end of word, we exit the method
            if (nodes[i].isEndOfWord) return;
            // Clear the children dictionary
            nodes[i].children.Clear();
            // Set the node to null
            nodes[i] = null;
        }
    }

    /// <summary>
    /// Removes the passed word from the Trie.
    /// There is a chance that the word is the prefix to
    /// a longer word in the trie.
    /// Meaning if we delete it, we'd be removing any references
    /// to the rest of the word, essentially deleting the whole branch.
    /// E.g. the word "Car" is a prefix to the word "Cart".
    /// If we delete "Car", we'd remove the parent for "t".
    /// Therefore, what we'll do is we'll simply set isEndOfWord to false
    /// if the current node has any children.
    /// </summary>
    /// <param name="word"></param>
    public void Remove(string word)
    {
        // Get a reference to our root node for traversing
        Node node = root;
        // Create an array of parent nodes for deleting if necessary
        Node[] parentNodes = new Node[word.Length - 1];

        if (word.Length <= 0) throw new ArgumentException("Word parameter cannot be an empty string!");

        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];

            // If character doesn't exist in node.children, then we can
            // assume that the word doesn't exist and exit out the loop
            if (!node.children.ContainsKey(ch)) break;

            // Add current node to parentNodes array.
            // Make sure we don't include the root node so it's not deleted.
            // Because we don't delete the root node, the initial character will still exist
            // E.g. delete "Card", "C" will still exists because it's in the root.children
            if (i > 0 && node != root) parentNodes[i-1] = node;
            // Otherwise, we continue to traverse the branch
            node = node.children[ch];
        }

        // If after the iteration we find that this is not an end of word
        if (!node.isEndOfWord)
        {
            Console.WriteLine($"{word} is not a valid word in the trie.");
        }
        // Otherwise, we handle the case where we reach the leaf node
        else if (node.isEndOfWord && node.children.Count <= 0)
        {
            Remove(parentNodes);
            Console.WriteLine($"Successfully removed the word: {word}");
        }
        // Handle the case it's an end of word, but is prefix to longer word
        else
        {
            node.isEndOfWord = false;
            Console.WriteLine($"Successfully removed the word: {word}");
        }
    }
}

class MainClass
{
    public static void Main()
    {
        Trie t = new Trie();

        Console.WriteLine("Trie");
        Console.WriteLine("-----------------");
        Console.WriteLine();

        t.Insert("Car");
        t.Insert("Card");
        t.Insert("Cot");
        t.Insert("Cots");
        t.Insert("Trie");
        t.Insert("Try");
        Console.WriteLine(); 
        t.Insert("Card");
        t.Insert("Try");
        Console.WriteLine();

        Console.WriteLine($"Contains 'Card': {t.Contains("Card")}");
        Console.WriteLine($"Contains 'Trie': {t.Contains("Trie")}");
        Console.WriteLine($"Contains 'Cart': {t.Contains("Cart")}");
        Console.WriteLine($"Contains 'Word': {t.Contains("Word")}");
        Console.WriteLine();

        t.Remove("Word");
        t.Remove("Car");
        t.Remove("Tr");
        t.Remove("Card");
        t.Remove("Cart");
        t.Remove("Cots");
        Console.WriteLine($"Contains 'Cot': {t.Contains("Cot")}");

        // Expected Output
        // ----------------
        // Successfully inserted the word: Car
        // Successfully inserted the word: Card
        // Successfully inserted the word: Cot
        // Successfully inserted the word: Cots
        // Successfully inserted the word: Trie
        // Successfully inserted the word: Try
        //
        // Already exists in the Trie: Card
        // Already exists in the Trie: Try
        //
        // Contains 'Card': True
        // Contains 'Trie': True
        // Contains 'Cart': False
        // Contains 'Word': False
        //
        // Word is not a valid word in the trie.
        // Successfully removed the word: Car
        // Tr is not a valid word in the trie.
        // Successfully removed the word: Card
        // Cart is not a valid word in the trie.
        // Successfully removed the word: Cots
        // Contains 'Cot': True
    }
}
