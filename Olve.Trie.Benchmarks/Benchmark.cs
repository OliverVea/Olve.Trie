using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Olve.Trie.Benchmarks.Report;

namespace Olve.Trie.Benchmarks;

public class Benchmark<TBenchmark>(string id, string title) : IBenchmark
{
    public string Id { get; } = id;
    public string Title { get; } = title;

    public Summary Run()
    {
        var summary = BenchmarkRunner.Run<TBenchmark>();

        var results = new BenchmarkResults
        {
            Id = Id,
            Title = Id,
            SourceFile = typeof(TBenchmark).Name + ".cs",
            ResultsTable = summary.Table
        };

        BenchmarkReportHelper.ReportBenchmarkToReadme(results);

        return summary;
    }
}