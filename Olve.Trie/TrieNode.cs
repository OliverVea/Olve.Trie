using System.Diagnostics.CodeAnalysis;

namespace Olve.Trie;

internal class TrieNode
{
    private readonly Lazy<Dictionary<char, TrieNode>> _children = new();
    public IReadOnlyCollection<TrieNode> Children => _children.IsValueCreated ? _children.Value.Values : [];

    public string? Word { get; set; }
    public bool IsWord => Word != null;

    public bool TryGetChild(char c, [NotNullWhen(true)] out TrieNode? child)
    {
        if (!_children.IsValueCreated)
        {
            child = null;
            return false;
        }

        return _children.Value.TryGetValue(c, out child);
    }

    public TrieNode AddChild(char c)
    {
        if (_children.Value.TryGetValue(c, out var child))
        {
            return child;
        }

        child = new TrieNode();
        _children.Value.Add(c, child);
        return child;
    }

    public void Clear()
    {
        Word = null;

        if (_children.IsValueCreated)
        {
            _children.Value.Clear();
        }
    }

    public bool Remove(char c)
    {
        if (_children.IsValueCreated)
        {
            return _children.Value.Remove(c);
        }

        return false;
    }
}