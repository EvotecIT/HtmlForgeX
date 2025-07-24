using System.Text.Json;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Validates JSON conversion for the <see cref="ApexChartType"/> enumeration.
/// </summary>
[TestClass]
public class TestApexChartTypeConverter {
    [TestMethod]
    public void ApexChartType_SerializesAndDeserializes() {
        var type = ApexChartType.Bar;
        var json = JsonSerializer.Serialize(type);
        Assert.AreEqual("\"bar\"", json);
        var back = JsonSerializer.Deserialize<ApexChartType>(json);
        Assert.AreEqual(type, back);
    }
}