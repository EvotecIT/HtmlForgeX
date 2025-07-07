using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace HtmlForgeX.Tests;

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
