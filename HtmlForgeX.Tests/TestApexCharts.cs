using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HtmlForgeX.Tests;

/// <summary>
/// Exercises core functionality of the <see cref="ApexCharts"/> container.
/// </summary>
[TestClass]
public class TestApexCharts {
    [TestMethod]
    public void ApexCharts_GeneratesPieChartHtml() {
        var chart = new ApexCharts();
        chart.AddPie("A", 5);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("ApexCharts"));
        Assert.IsTrue(html.Contains("\"pie\""));
        Assert.IsTrue(html.Contains("A"));
    }

    [TestMethod]
    public void ApexCharts_SupportsAdditionalTypes() {
        var chart = new ApexCharts();
        chart.AddArea("Area", 1)
            .AddTreemap("Tree", 2)
            .AddRadar("Radar", 3)
            .AddHeatmap("Heat", new[] { ("X1", 4.0) })
            .AddMixed("Mixed", 5);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("area") || html.Contains("treemap") || html.Contains("radar") || html.Contains("heatmap") || html.Contains("mixed"));
    }

    [TestMethod]
    public void ApexCharts_FluentOptions() {
        var chart = new ApexCharts();
        chart.AddArea("A", 1)
            .Grid(g => g.PaddingOptions(p => p.All(2)))
            .PlotOptions(o => o.HeatmapOptions(h => h.RadiusValue(3)))
            .Legend(l => l.ShowLegend(true))
            .Tooltip(t => t.Enable(true))
            .Theme(th => th.ModeValue(ApexThemeMode.Dark));

        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"padding\""));
        Assert.IsTrue(html.Contains("\"radius\""));
        Assert.IsTrue(html.Contains("dark"));
    }

    [TestMethod]
    public void ApexCharts_LargeHeatmapData() {
        var chart = new ApexCharts();
        for (var s = 0; s < 5; s++) {
            var points = new List<(string X, double Y)>();
            for (var i = 0; i < 10; i++) {
                points.Add(($"W{i}", i));
            }
            chart.AddHeatmap($"S{s}", points);
        }

        Assert.AreEqual(5, chart.HeatmapSeries.Count);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"heatmap\""));
    }

    [TestMethod]
    public void ApexCharts_WrapsScriptInDomContentLoaded() {
        var chart = new ApexCharts();
        chart.AddPie("A", 5);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("DOMContentLoaded"));
    }
}
