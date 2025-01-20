using System.Runtime.CompilerServices;
using Olve.Trie;
using Olve.Trie.Profiling;

var words = TestDataHelper.GetTestData()[..300_000];

var trie = CreateTrie(words);
var count = LookupInTrie(trie, words);

Console.WriteLine(count);

return;

[MethodImpl(MethodImplOptions.NoInlining)]
static Trie CreateTrie(string[] words)
{
    var trie = new Trie();

    foreach (var word in words)
    {
        trie.Add(word);
    }

    return trie;
}

[MethodImpl(MethodImplOptions.NoInlining)]
static int LookupInTrie(Trie trie, string[] words)
{
    var random = new Random(0);
    var count = 0;

    for (var i = 0; i < 200; i++)
    {
        var word = words[i];
        var len = random.Next() % word.Length;
        var prefix = word[.. len];

        var results = trie.ListWithPrefix(prefix);

        count += results.Count;
    }


    return count;
}

