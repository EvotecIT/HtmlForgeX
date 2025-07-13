using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Available Chart.js chart types.
/// </summary>
[JsonConverter(typeof(ChartJsTypeConverter))]
public enum ChartJsType {
    Line,
    Bar,
    Pie
}

public class ChartJsTypeConverter : JsonConverter<ChartJsType> {
    public override ChartJsType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value switch {
            "line" => ChartJsType.Line,
            "bar" => ChartJsType.Bar,
            "pie" => ChartJsType.Pie,
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, ChartJsType value, JsonSerializerOptions options) {
        var stringValue = value switch {
            ChartJsType.Line => "line",
            ChartJsType.Bar => "bar",
            ChartJsType.Pie => "pie",
            _ => throw new JsonException()
        };
        writer.WriteStringValue(stringValue);
    }
}
