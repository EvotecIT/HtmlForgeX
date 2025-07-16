using System.Text.Json;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        using var doc = new Document();
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

    [TestMethod]
    public void ChartJsType_NewValuesSerializeDeserialize() {
        foreach (var pair in new[] {
            (ChartJsType.Radar, "\"radar\""),
            (ChartJsType.Scatter, "\"scatter\""),
            (ChartJsType.Bubble, "\"bubble\"") }) {
            var json = JsonSerializer.Serialize(pair.Item1);
            Assert.AreEqual(pair.Item2, json);
            var back = JsonSerializer.Deserialize<ChartJsType>(json);
            Assert.AreEqual(pair.Item1, back);
        }
    }

    [TestMethod]
    public void ChartJs_BuilderMethodsSetType() {
        var radar = new ChartJs().Radar();
        Assert.AreEqual(ChartJsType.Radar, radar.Type);
        var scatter = new ChartJs().Scatter();
        Assert.AreEqual(ChartJsType.Scatter, scatter.Type);
        var bubble = new ChartJs().Bubble();
        Assert.AreEqual(ChartJsType.Bubble, bubble.Type);
    }

    [TestMethod]
    public void ChartJs_ScatterHtmlContainsPoints() {
        var chart = new ChartJs().Scatter()
            .AddPoint(1, 2)
            .AddPoint(2, 3);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"scatter\""));
        Assert.IsTrue(html.Contains("\"x\": 1"));
    }

    [TestMethod]
    public void ChartJs_BubbleHtmlContainsRadius() {
        var chart = new ChartJs().Bubble()
            .AddBubble(1, 2, 5);
        var html = chart.ToString();
        Assert.IsTrue(html.Contains("\"bubble\""));
        Assert.IsTrue(html.Contains("\"r\": 5"));
    }
}