using System.Text.RegularExpressions;

using BenchmarkDotNet.Attributes;

using HtmlForgeX;

[MemoryDiagnoser]
public class RegexBenchmarks {
    private static readonly Regex StaticRegex = new(@"(\d+)", RegexOptions.Compiled);
    private const string ColorString = "gray500";

    [Benchmark(Baseline = true)]
    public string LocalRegex() {
        var regex = new Regex(@"(\d+)");
        if (regex.IsMatch(ColorString)) {
            return regex.Replace(ColorString, "-$1");
        }
        return ColorString;
    }

    [Benchmark]
    public string StaticRegexBenchmark() {
        if (StaticRegex.IsMatch(ColorString)) {
            return StaticRegex.Replace(ColorString, "-$1");
        }
        return ColorString;
    }
}