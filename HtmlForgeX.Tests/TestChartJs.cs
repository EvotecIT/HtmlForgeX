using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests creation and rendering of Chart.js based components.
/// </summary>
[TestClass]
public class TestChartJs {
    [TestMethod]
    public void ChartJs_GeneratesLineChartHtml() {
        var chart = new ChartJs();
        chart.Line().AddData("A", 1).AddData("B", 2);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"line\""));
        Assert.IsTrue(html.Contains("A"));
        Assert.IsTrue(html.Contains("2"));
    }

    [TestMethod]
    public void ChartJs_RegistersLibrary() {
        var doc = new Document();
        doc.Body.Add(element => {
            element.ChartJs(c => c.AddData("A", 1));
        });
        var html = doc.ToString();
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.ChartJs));
    }

    [TestMethod]
    public void ChartJsType_SerializesAndDeserializes() {
        var type = ChartJsType.Pie;
        var json = JsonSerializer.Serialize(type);
        Assert.AreEqual("\"pie\"", json);
        var back = JsonSerializer.Deserialize<ChartJsType>(json);
        Assert.AreEqual(type, back);
    }
}
