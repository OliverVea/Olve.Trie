using BenchmarkDotNet.Attributes;
using Olve.Trie.Tests.Shared;

namespace Olve.Trie.Benchmarks.Benchmarks;

[InvocationCount(16)]
public class ContainsBenchmark
{
    private string[] _allWords = null!;
    private string[] _words = null!;

    private NaiveArrayTrie _olveNaiveArrayTrie = null!;
    private KTrie.Trie _kTrie = null!;
    private HashSet<string> _hashSet = null!;


    [Params(100, 10_000, 100_000)]
    public int TrieSize { get; set; }

    [Params(5, 500, 50000)]
    public int Words { get; set; }

    [Params(0.0f, 0.5f, 1.0f)]
    public float MissRate { get; set; }

    private int Hits => Words - Misses;
    private int Misses => (int)(Words * MissRate);

    [GlobalSetup]
    public void GlobalSetup()
    {
        _allWords = TestDataHelper.GetTestData();
    }

    [IterationSetup]
    public void Setup()
    {
        var wordsInTrie = _allWords[.. TrieSize];

        var hits = _allWords[..Hits];
        var misses = _allWords[TrieSize..][..Misses];

        _olveNaiveArrayTrie = [..wordsInTrie];
        _kTrie = [..wordsInTrie];
        _hashSet = [..wordsInTrie];

        _words = [..hits, ..misses];
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _words = [];
        _olveNaiveArrayTrie = null!;
        _kTrie = null!;
    }

    [Benchmark(Baseline = true)]
    public int KTrie()
    {
        var result = 0;

        foreach (var word in _words)
        {
            if (_kTrie.Contains(word))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public int Olve_NaiveArrayTrie()
    {
        var result = 0;

        foreach (var word in _words)
        {
            if (_olveNaiveArrayTrie.Contains(word))
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public int HashSet()
    {
        var result = 0;

        foreach (var word in _words)
        {
            if (_hashSet.Contains(word))
            {
                result++;
            }
        }

        return result;
    }
}