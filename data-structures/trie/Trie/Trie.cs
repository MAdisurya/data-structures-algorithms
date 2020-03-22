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
    }
}
