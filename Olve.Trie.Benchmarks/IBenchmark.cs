using BenchmarkDotNet.Reports;

namespace Olve.Trie.Benchmarks;

public interface IBenchmark
{
    string Id { get; }
    string Title { get; }

    Summary Run();
}