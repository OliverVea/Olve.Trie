using System.Collections;

namespace Olve.Trie;

public sealed partial class Trie : ICollection<string>
{
    public void Add(string item)
    {
        Add(item.AsSpan());
    }

    public bool Contains(string item) => Contains(item.AsSpan(), false);

    public void CopyTo(string[] array, int arrayIndex)
    {
        foreach (var item in this)
        {
            array[arrayIndex++] = item;
        }
    }

    public bool Remove(string item) => Remove(item.AsSpan());

    public bool IsReadOnly => false;

    public IEnumerator<string> GetEnumerator() => Words.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}