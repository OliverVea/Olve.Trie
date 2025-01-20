using System.Runtime.CompilerServices;

namespace Olve.Trie;

public sealed partial class Trie
{
    private readonly TrieNode _root = new('\0');

    public int Count { get; private set; }

    public void Add(ReadOnlySpan<char> item)
    {
        var node = _root;

        foreach (var ch in item)
        {
            node = GetOrAddNode(node, ch);
        }

        if (node.Word is not null)
        {
            return;
        }

        node.Word = item.ToString();
        Count++;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TrieNode GetOrAddNode(TrieNode parent, char ch)
    {
        var index = ch % TrieNode.ChildCount;
        var list = parent.Children[index];

        if (list == null)
        {
            list = [];
            parent.Children[index] = list;
        }

        foreach (var child in list)
        {
            if (child.Char == ch)
            {
                return child;
            }
        }

        var node = new TrieNode(ch);
        list.Add(node);

        return node;
    }

    public void Clear()
    {
        foreach (var childList in _root.Children)
        {
            childList?.Clear();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TrieNode? GetChild(TrieNode parent, char ch)
    {
        var index = ch % TrieNode.ChildCount;
        var list = parent.Children[index];

        if (list == null)
        {
            return null;
        }

        foreach (var child in list)
        {
            if (child.Char == ch)
            {
                return child;
            }
        }

        return null;
    }

    public bool Contains(ReadOnlySpan<char> item) => Contains(item, false);
    public bool ContainsPrefix(ReadOnlySpan<char> item) => Contains(item, true);

    private bool Contains(ReadOnlySpan<char> item, bool matchPrefix)
    {
        var node = _root;

        foreach (var ch in item)
        {
            node = GetChild(node, ch);

            if (node is null)
            {
                return false;
            }
        }

        return matchPrefix || node.Word is not null;
    }

    public IReadOnlyList<string> ListWithPrefix(string pattern) => ListWithPrefix(pattern.AsSpan());

    private IReadOnlyList<string> ListWithPrefix(ReadOnlySpan<char> prefix)
    {
        List<string> results = [];
        var node = _root;

        foreach (var ch in prefix)
        {
            node = GetChild(node, ch);

            if (node is null)
            {
                return results;
            }
        }

        ListWords(node, results);

        return results;
    }

    public IEnumerable<string> EnumerateWithPrefix(string pattern) => EnumerateWithPrefix(pattern.AsSpan());
    public IEnumerable<string> EnumerateWithPrefix(ReadOnlySpan<char> prefix)
    {
        var node = FindNode(prefix);
        if (node is null)
        {
            return [];
        }

        return EnumerateWords(node);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TrieNode? FindNode(ReadOnlySpan<char> item)
    {
        var node = _root;

        foreach (var ch in item)
        {
            node = GetChild(node, ch);

            if (node is null)
            {
                return null;
            }
        }

        return node;
    }

    public bool Remove(ReadOnlySpan<char> item)
    {
        throw new NotImplementedException();
    }



    private static List<string> ListWords(TrieNode node)
    {
        List<string> words = [];
        ListWords(node, words);
        return words;
    }

    public IReadOnlyList<string> ListWords() => ListWords(_root);
    private static void ListWords(TrieNode node, List<string> words)
    {
        if (node.Word is not null)
        {
            words.Add(node.Word);
        }

        foreach (var childList in node.Children)
        {
            if (childList is null)
            {
                continue;
            }

            foreach (var child in childList)
            {
                ListWords(child, words);
            }
        }
    }

    public IEnumerable<string> Words => EnumerateWords(_root);
    private static IEnumerable<string> EnumerateWords(TrieNode node)
    {
        if (node.Word is not null)
        {
            yield return node.Word;
        }

        foreach (var childList in node.Children)
        {
            if (childList is null)
            {
                continue;
            }

            foreach (var child in childList)
            {
                foreach (var word in EnumerateWords(child))
                {
                    yield return word;
                }
            }
        }
    }
}