using Olve.Trie.Benchmarks;
using Olve.Trie.Benchmarks.Benchmarks;
using Spectre.Console;

IBenchmark[] benchmarks = [
    new Benchmark<ConstructTrieBenchmark>("construct-trie", "Initialization"),
    new Benchmark<ListWithPrefixBenchmark>("list-with-prefix", "Prefix Match"),
    new Benchmark<EnumerateTopKWithPrefixBenchmark>("enumerate-k-prefix", "Top K Prefix Match"),
];


var prompt = new MultiSelectionPrompt<string> { Title = "Select benchmarks to run" };

foreach (var benchmark in benchmarks)
{
    prompt.AddChoice(benchmark.Id);
}

var idsToRun = AnsiConsole.Prompt(prompt);

var benchmarksById = benchmarks.ToDictionary(x => x.Id);

foreach (var idToRun in idsToRun)
{
    var benchmark = benchmarksById[idToRun];
    benchmark.Run();
}
