using System.Collections;

namespace Olve.Trie;

public abstract partial class Trie<TNode>
{
    public bool Contains(string item) => Contains(item.AsSpan(), false);

    public void CopyTo(string[] array, int arrayIndex)
    {
        foreach (var item in this)
        {
            array[arrayIndex++] = item;
        }
    }

    public bool IsReadOnly => false;

    public IEnumerator<string> GetEnumerator() => ListWords().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}