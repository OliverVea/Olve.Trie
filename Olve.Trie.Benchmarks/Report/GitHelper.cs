using System.Diagnostics;

namespace Olve.Trie.Benchmarks.Report;

public static class GitHelper
{
    public static string GetGitHash()
    {
        using var process = new Process();

        process.StartInfo = new ProcessStartInfo
        {
            FileName = "git",
            Arguments = "rev-parse HEAD",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        process.Start();
        var gitHash = process.StandardOutput.ReadToEnd().Trim();
        process.WaitForExit();

        return gitHash;
    }
}