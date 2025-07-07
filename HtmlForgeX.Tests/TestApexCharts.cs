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
}
