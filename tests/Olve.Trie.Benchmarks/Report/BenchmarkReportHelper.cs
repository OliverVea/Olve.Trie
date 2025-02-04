﻿using System.Text.RegularExpressions;

namespace Olve.Trie.Benchmarks.Report;

public static partial class BenchmarkReportHelper
{
    private const string BenchmarkTemplatePath = "./Report/BenchmarkTemplate.md";
    private const string BenchmarkEndMarker = "<!-- BENCHMARK_END -->";

    [GeneratedRegex("^<!--\\s*BENCHMARK_ID:\\s*\"([\\w,\\-]+)\"\\s*-->$")]
    private static partial Regex BenchmarkIdPattern();

    private const string SourceTemplate = "https://github.com/OliverVea/Olve.Trie/blob/{0}/Olve.Trie.Benchmarks/Benchmarks/{1}";

    public static void ReportBenchmarkToReadme(BenchmarkResults results)
    {
        var root = GitHelper.GetRepoRoot();
        var benchmarksPath = Path.Combine(root, "README.md");

        ReportBenchmark(results, benchmarksPath);
    }

    private static void ReportBenchmark(BenchmarkResults results, string benchmarksPath)
    {
        var reportLines = File.ReadLines(BenchmarkTemplatePath).ToList();
        var gitHash = GitHelper.GetGitHash();

        for (var i = 0; i < reportLines.Count; i++)
        {
            reportLines[i] = reportLines[i]
                .Replace("$Title", results.Title)
                .Replace("$DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("$ResultsTable", TableExportHelper.ToMarkdownTable(results.ResultsTable))
                .Replace("$Source", string.Format(SourceTemplate, gitHash, results.SourceFile));
        }

        var benchmarksLines = File
            .ReadLines(benchmarksPath)
            .ToList();

        var idLine = benchmarksLines.FindIndex(line => BenchmarkIdPattern().IsMatch(line) && BenchmarkIdPattern().Match(line).Groups[1].Value == results.Id);
        var endLine = benchmarksLines.FindIndex(idLine, line => line.Contains(BenchmarkEndMarker));

        benchmarksLines.RemoveRange(idLine + 1, endLine - idLine - 1);
        benchmarksLines.InsertRange(idLine + 1, reportLines);

        File.WriteAllLines(benchmarksPath, benchmarksLines);
    }
}