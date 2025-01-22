namespace Olve.Trie;

public sealed class NaiveArrayTrieNode : ITrieNode
{
    public string? Word { get; set; }
    public char Key { get; init; }

    private NaiveArrayTrieNode[]? _children = [];

    public IReadOnlyCollection<ITrieNode> Children => _children ?? [];

    public ITrieNode GetOrAdd(char key)
    {
        _children ??= [];

        for (var i = 0; i < _children.Length; i++)
        {
            if (_children[i].Key == key)
            {
                return _children[i];
            }
        }

        var node = new NaiveArrayTrieNode { Key = key };

        var children = new NaiveArrayTrieNode[_children.Length + 1];
        Array.Copy(_children, children, _children.Length);
        _children = children;

        _children[^1] = node;

        return node;
    }

    public ITrieNode? Get(char ch)
    {
        if (_children is null)
        {
            return null;
        }

        for (var i = 0; i < _children.Length; i++)
        {
            if (_children[i].Key == ch)
            {
                return _children[i];
            }
        }

        return null;
    }

    public bool Remove(char key)
    {
        var index = -1;

        if (_children is null)
        {
            return false;
        }

        for (var i = 0; i < _children.Length; i++)
        {
            if (_children[i].Key == key)
            {
                index = i;
                break;
            }
        }

        if (index == 0)
        {
            return false;
        }

        var children = new NaiveArrayTrieNode[_children.Length - 1];

        Array.Copy(_children, children, index);
        Array.Copy(_children, index + 1, children, index, _children.Length - 1 - index);

        _children = children;

        return true;
    }

    public void Clear()
    {
        _children = [];
    }
}