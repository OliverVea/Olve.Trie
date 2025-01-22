using BenchmarkDotNet.Reports;

namespace Olve.Trie.Benchmarks.Report;

public class BenchmarkResults
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string SourceFile { get; init; }
    public required SummaryTable ResultsTable { get; init; }
}