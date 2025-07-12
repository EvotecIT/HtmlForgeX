using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

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
    public void ApexCharts_GeneratesRadarChartHtml() {
        var chart = new ApexCharts();
        chart.AddRadar("A", 5);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"radar\""));
    }

    [TestMethod]
    public void ApexCharts_GeneratesHeatmapChartHtml() {
        var chart = new ApexCharts();
        chart.AddHeatmap("A", 1);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"heatmap\""));
    }

    [TestMethod]
    public void ApexCharts_GeneratesMixedChartHtml() {
        var chart = new ApexCharts();
        chart.AddMixed("bar", "Bar", new[] { 1.0, 2.0 });
        chart.AddMixed("line", "Line", new[] { 2.0, 3.0 });
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"series\""));
        Assert.IsTrue(html.Contains("\"bar\""));
        Assert.IsTrue(html.Contains("\"line\""));
    }
}
