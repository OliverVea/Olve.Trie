using BenchmarkDotNet.Attributes;
using Olve.Trie.Tests.Shared;

namespace Olve.Trie.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[InvocationCount(16)]
public class ConstructTrieBenchmark
{
    private string[] _allWords = null!;
    private string[] _words = null!;

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
    }

    [Benchmark(Baseline = true)]
    public KTrie.Trie KTrie()
    {
        return [.._words];
    }

    [Benchmark]
    public NaiveArrayTrie Olve_NaiveArrayTrie()
    {
        return [.._words];
    }
}