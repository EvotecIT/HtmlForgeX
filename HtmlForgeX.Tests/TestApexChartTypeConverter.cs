using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestApexChartTypeConverter {
    [TestMethod]
    public void ApexChartType_SerializesAndDeserializes() {
        var json = JsonSerializer.Serialize(ApexChartType.Bar);
        Assert.AreEqual("\"bar\"", json);

        var types = new[] { ApexChartType.Bar, ApexChartType.Radar, ApexChartType.Heatmap, ApexChartType.Mixed };
        foreach (var type in types) {
            var roundtrip = JsonSerializer.Deserialize<ApexChartType>(JsonSerializer.Serialize(type));
            Assert.AreEqual(type, roundtrip);
        }
    }
}
