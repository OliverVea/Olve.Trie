namespace Olve.Trie;

internal class TrieNode(char ch)
{
    public const int ChildCount = 'z' - 'a' + 1;

    public char Char { get; } = ch;
    public string? Word { get; set; }
    public List<TrieNode>?[] Children { get; } = new List<TrieNode>?[ChildCount];
}