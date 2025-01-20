using System.Runtime.CompilerServices;
using Olve.Trie;
using Olve.Trie.Profiling;

var words = TestDataHelper.GetTestData()[..10_000];

var trie = NewTrie(words);
var count = ListWithPrefix(trie, words);
count += Contains(trie, words);

Console.WriteLine(count);

return;

[MethodImpl(MethodImplOptions.NoInlining)]
static Trie NewTrie(string[] words)
{
    var trie = new Trie();

    foreach (var word in words)
    {
        trie.Add(word);
    }

    return trie;
}

[MethodImpl(MethodImplOptions.NoInlining)]
static int ListWithPrefix(Trie trie, string[] words)
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

[MethodImpl(MethodImplOptions.NoInlining)]
static int Contains(Trie trie, string[] words)
{
    var random = new Random(0);
    var count = 0;

    for (var i = 0; i < 200; i++)
    {
        var word = words[i];

        var changeWord = random.Next() % 2 == 0;
        if (changeWord)
        {
            var index = random.Next() % word.Length;
            word = word[.. index] + (char)(random.Next() % 26 + 'a') + word[(index + 1)..];
        }

        var len = random.Next() % word.Length;
        var prefix = word[.. len];

        var contains = trie.Contains(prefix);

        if (contains)
        {
            count++;
        }
    }

    return count;
}

