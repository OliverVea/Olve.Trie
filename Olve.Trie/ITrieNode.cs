namespace Olve.Trie;

public interface ITrieNode
{
    string? Word { get; set; }
    char Key { get; }
    IReadOnlyCollection<ITrieNode> Children { get; }
    ITrieNode GetOrAdd(char key);
    ITrieNode? Get(char key);
    bool Remove(char key);
    void Clear();
}