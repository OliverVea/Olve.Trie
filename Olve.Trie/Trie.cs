namespace Olve.Trie;

public abstract partial class Trie<TNode> : ITrie
    where TNode : ITrieNode, new()
{
    private readonly TNode _root = new();

    public int Count { get; private set; }

    public void Add(string item)
    {
        ITrieNode node = _root;

        foreach (var ch in item)
        {
            var child = node.GetOrAdd(ch);

            node = child;
        }

        if (node.Word is not null)
        {
            return;
        }

        node.Word = item;
        Count++;
    }

    public void Clear()
    {
        _root.Clear();
        Count = 0;
    }


    private bool Contains(ReadOnlySpan<char> item, bool matchPrefix)
    {
        ITrieNode? node = _root;

        foreach (var ch in item)
        {
            node = node.Get(ch);

            if (node == null)
            {
                return false;
            }
        }

        return matchPrefix || node.Word is not null;
    }
    public bool Remove(string item)
    {
        return Remove(item.AsSpan(), _root);
    }

    private bool Remove(ReadOnlySpan<char> item, ITrieNode node)
    {
        if (item.Length == 0)
        {
            if (node.Word is null)
            {
                return false;
            }

            node.Word = null;
            Count--;
            return true;
        }

        var child = node.Get(item[0]);
        if (child is null)
        {
            return false;
        }

        var removed = Remove(item[1..], child);
        if (!removed)
        {
            return false;
        }

        if (child.Word == null && child.Children.Count == 0)
        {
            node.Remove(item[0]);
        }

        return true;
    }

    public IReadOnlyList<string> ListWords() => ListWords(_root);

    private IReadOnlyList<string> ListWords(ITrieNode node)
    {
        List<string> words = new(Count);

        ListWords(node, words);

        return words;
    }

    private static void ListWords(ITrieNode node, List<string> words)
    {
        if (node.Word is not null)
        {
            words.Add(node.Word);
        }

        foreach (var child in node.Children)
        {
            ListWords(child, words);
        }
    }

    public IEnumerable<string> EnumerateWords() => EnumerateWords(_root);
    private IEnumerable<string> EnumerateWords(ITrieNode root)
    {
        var stack = new Stack<ITrieNode>();
        stack.Push(root);

        while (stack.TryPop(out var node))
        {
            if (node.Word is { } word)
            {
                yield return word;
            }

            foreach (var child in node.Children)
            {
                stack.Push(child);
            }
        }
    }

    public IReadOnlyList<string> ListWithPrefix(string prefix) => ListWithPrefix(prefix.AsSpan());

    private IReadOnlyList<string> ListWithPrefix(ReadOnlySpan<char> prefix)
    {
        ITrieNode? node = _root;

        foreach (var ch in prefix)
        {
            node = node.Get(ch);

            if (node == null)
            {
                return [];
            }
        }

        List<string> words = [];

        ListWords(node, words);

        return words;
    }

    public IEnumerable<string> EnumerateWithPrefix(string prefix) => EnumerateWithPrefix(prefix.AsSpan());

    public IEnumerable<string> EnumerateWithPrefix(ReadOnlySpan<char> prefix)
    {
        ITrieNode? node = _root;

        for (var i = 0; i < prefix.Length; i++)
        {
            var ch = prefix[i];
            node = node.Get(ch);

            if (node == null)
            {
                return [];
            }
        }

        return EnumerateWords(node);
    }
}