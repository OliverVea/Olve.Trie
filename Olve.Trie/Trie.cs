namespace Olve.Trie;

public sealed partial class Trie
{
    private readonly TrieNode _root = new();

    public int Count { get; private set; }

    public void Add(ReadOnlySpan<char> item)
    {
        var node = _root;

        foreach (var ch in item)
        {
            if (!node.TryGetChild(ch, out var child))
            {
                child = node.AddChild(ch);
            }

            node = child;
        }

        if (!node.IsWord)
        {
            node.Word = item.ToString();
            Count++;
        }
    }

    public void Clear() => _root.Clear();

    public bool Contains(ReadOnlySpan<char> item) => Contains(item, false);
    public bool ContainsPrefix(ReadOnlySpan<char> item) => Contains(item, true);

    private bool Contains(ReadOnlySpan<char> item, bool matchPrefix)
    {
        var node = _root;

        foreach (var ch in item)
        {
            if (!node.TryGetChild(ch, out var child))
            {
                return false;
            }

            node = child;
        }

        return matchPrefix || node.IsWord;
    }

    public IEnumerable<string> Match(ReadOnlySpan<char?> pattern) => Match(_root, pattern);
    private static IEnumerable<string> Match(TrieNode node, ReadOnlySpan<char?> pattern)
    {
        if (pattern.IsEmpty)
        {
            if (node.Word is {} word)
            {
                return GetWords(node)
                    .Prepend(word);
            }

            return GetWords(node);
        }

        var nextPattern = pattern[1..];

        if (pattern[0] is { } ch)
        {
            if (node.TryGetChild(ch, out var child))
            {
                return Match(child, nextPattern);
            }

            return [];
        }

        IEnumerable<string> words = [];

        foreach (var child in node.Children)
        {
            var nextWords = Match(child, nextPattern);
            words = words.Concat(nextWords);
        }

        return words;
    }

    public bool Remove(ReadOnlySpan<char> item)
    {
        Stack<TrieNode> stack = new();

        var node = _root;

        foreach (var ch in item)
        {
            if (!node.TryGetChild(ch, out var child))
            {
                return false;
            }

            stack.Push(node);
            node = child;
        }

        if (!node.IsWord)
        {
            return false;
        }

        node.Word = null;
        stack.Push(node);

        for (var i = item.Length - 1; i >= 0; i--)
        {
            var parent = stack.Pop();

            parent.Remove(item[i]);

            if (parent.Children.Count > 0 || parent.IsWord)
            {
                break;
            }

            parent.Clear();
        }

        Count--;
        return true;
    }


    public IEnumerable<string> Words => GetWords(_root);
    private static IEnumerable<string> GetWords(TrieNode node)
    {
        if (node.IsWord)
        {
            yield return node.Word!;
        }

        foreach (var child in node.Children)
        {
            foreach (var word in GetWords(child))
            {
                yield return word;
            }
        }
    }
}