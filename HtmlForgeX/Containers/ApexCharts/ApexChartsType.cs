using System.Text.Json.Serialization;
using System.Text.Json;

namespace HtmlForgeX;

[JsonConverter(typeof(ApexChartTypeConverter))]
public enum ApexChartType {
    Pie,
    Donut,
    Bar,
    RadialBar
}

public class ApexChartTypeConverter : JsonConverter<ApexChartType> {
    public override ApexChartType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();

        return value switch {
            "pie" => ApexChartType.Pie,
            "donut" => ApexChartType.Donut,
            "bar" => ApexChartType.Bar,
            "radialBar" => ApexChartType.RadialBar,
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, ApexChartType value, JsonSerializerOptions options) {
        var stringValue = value switch {
            ApexChartType.Pie => "pie",
            ApexChartType.Donut => "donut",
            ApexChartType.Bar => "bar",
            ApexChartType.RadialBar => "radialBar",
            _ => throw new JsonException()
        };

        writer.WriteStringValue(stringValue);
    }
}