using BenchmarkDotNet.Attributes;
using Olve.Trie.Tests.Shared;

namespace Olve.Trie.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[InvocationCount(16)]
public class ListWithPrefixBenchmark
{
    private string[] _allWords = null!;
    private string[] _words = null!;

    private NaiveArrayTrie _olveNaiveArrayTrie = null!;
    private KTrie.Trie _kTrie = null!;

    private readonly string[] _prefixes =
    [
        "abc",
        "k",
        "hello",
        "world",
        "pr",
        "ab",
        "lo",
        "st",
        "tom",
        "tr",
        "mor",
        "c",
        "tre",
        "se",
        "go",
        "vi",
        "gre",
        "pol",
        "kir",
        "ve"
    ];

    [Params(300, 10_000, 300_000)]
    public int WordCount { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _allWords = TestDataHelper.GetTestData();
    }

    [IterationSetup]
    public void Setup()
    {
        _words = _allWords[.. WordCount];

        _olveNaiveArrayTrie = [.._words];
        _kTrie = [.._words];
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _words = [];
        _olveNaiveArrayTrie = null!;
        _kTrie = null!;
    }

    [Benchmark(Baseline = true)]
    public List<IReadOnlyList<string>> KTrie_StartsWith()
    {
        var results = new List<IReadOnlyList<string>>();

        foreach (var prefix in _prefixes)
        {
            var matches = _kTrie.StartsWith(prefix).ToList();
            results.Add(matches);
        }

        return results;
    }

    [Benchmark]
    public List<IReadOnlyList<string>> Olve_NaiveArrayTrie_ListWithPrefix()
    {
        var results = new List<IReadOnlyList<string>>();

        foreach (var prefix in _prefixes)
        {
            var matches = _olveNaiveArrayTrie.ListWithPrefix(prefix);
            results.Add(matches);
        }

        return results;
    }

    [Benchmark]
    public List<IReadOnlyList<string>> Olve_NaiveArrayTrie_EnumerateWithPrefix()
    {
        var results = new List<IReadOnlyList<string>>();

        foreach (var prefix in _prefixes)
        {
            var matches = _olveNaiveArrayTrie.EnumerateWithPrefix(prefix).ToList();
            results.Add(matches);
        }

        return results;
    }
}