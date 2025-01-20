using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Olve.Trie.Benchmarks.Report;

namespace Olve.Trie.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class MatchBenchmark
{
    private string[] _allWords = null!;
    private string[] _words = null!;

    private Trie _olveTrie = null!;
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

        _olveTrie = [.._words];
        _kTrie = [.._words];
    }

    [Benchmark(Baseline = true)]
    public int KTrie()
    {
        var count = 0;

        foreach (var prefix in _prefixes)
        {
            var wordResults = _kTrie.StartsWith(prefix);
            count += wordResults.Count();
        }

        return count;
    }

    [Benchmark]
    public int Olve_List()
    {
        var count = 0;

        foreach (var prefix in _prefixes)
        {
            var matches = _olveTrie.ListWithPrefix(prefix);
            count += matches.Count;
        }

        return count;
    }

    [Benchmark]
    public int Olve_Enumerate()
    {
        var count = 0;

        foreach (var prefix in _prefixes)
        {
            var matches = _olveTrie.EnumerateWithPrefix(prefix);
            count += matches.Count();
        }

        return count;
    }

    public static Summary Run()
    {
        var summary = BenchmarkRunner.Run<MatchBenchmark>();

        var results = new BenchmarkResults
        {
            Id = "prefix-match",
            Title = "Prefix Match",
            SourceFile = "MatchBenchmark.cs",
            ResultsTable = summary.Table
        };

        BenchmarkReportHelper.ReportBenchmarkToReadme(results);

        return summary;
    }

    public static void Main()
    {
        Run();
    }
}