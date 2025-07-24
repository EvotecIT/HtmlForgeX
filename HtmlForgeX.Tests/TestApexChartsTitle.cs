using System.Text.Json;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Validates fluent configuration of the <see cref="ApexChartsTitle"/> component.
/// </summary>
[TestClass]
public class TestApexChartsTitle {
    [TestMethod]
    public void TitleBuilder_SetsProperties() {
        var title = new ApexChartsTitle()
            .Text("Demo")
            .Color("red")
            .FontSize("14px")
            .FontWeight("bold");

        Assert.IsTrue(title.IsSet);
        var json = JsonSerializer.Serialize(title);
        Assert.IsTrue(json.Contains("\"text\":\"Demo\""));
        Assert.IsTrue(json.Contains("red"));
    }

    [TestMethod]
    public void SubtitleBuilder_SetsProperties() {
        var sub = new ApexChartSubtitle()
            .Text("Sub")
            .Color(RGBColor.Blue)
            .FontSize("12px")
            .FontWeight("bold");

        Assert.IsTrue(sub.IsSet);
        var json = JsonSerializer.Serialize(sub);
        Assert.IsTrue(json.Contains("\"text\":\"Sub\""));
        Assert.IsTrue(json.Contains(RGBColor.Blue.ToHex()));
    }
}