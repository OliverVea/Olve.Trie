using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Olve.Trie.Benchmarks.Report;

namespace Olve.Trie.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
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
    public Trie Olve()
    {
        return [.._words];
    }

    public static Summary Run()
    {
        var summary = BenchmarkRunner.Run<ConstructTrieBenchmark>();

        var results = new BenchmarkResults
        {
            Id = "construct-trie",
            Title = "Construct Trie",
            SourceFile = "ConstructTrieBenchmark.cs",
            ResultsTable = summary.Table
        };

        BenchmarkReportHelper.ReportBenchmarkToReadme(results);

        return summary;
    }
}