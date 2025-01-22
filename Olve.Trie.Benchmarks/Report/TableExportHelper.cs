using System.Text;
using BenchmarkDotNet.Reports;

namespace Olve.Trie.Benchmarks.Report;

public static class TableExportHelper
{
    public static string ToMarkdownTable(SummaryTable summaryTable)
    {
        var columns = summaryTable.Columns.Where(x => x.NeedToShow)
            .ToArray();

        var header = columns.Select(x => x.Header).ToArray();
        List<string[]> resultsTable = [];

        foreach (var row in summaryTable.FullContent)
        {
            var resultRow = columns.Select(x => row[x.Index].ToString()).ToArray();
            resultsTable.Add(resultRow);
        }

        var resultsText = ToMarkdownTable(header, resultsTable);

        return resultsText;
    }

    public static string ToMarkdownTable(string[] header, List<string[]> content)
    {
        StringBuilder sb = new();

        sb.AppendLine("| " + string.Join(" | ", header) + " |");
        sb.AppendLine("| " + string.Join(" | ", header.Select(x => "---")) + " |");

        foreach (var row in content)
        {
            sb.AppendLine("| " + string.Join(" | ", row) + " |");
        }

        return sb.ToString();
    }
}