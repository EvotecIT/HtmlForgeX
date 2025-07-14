using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Available Chart.js chart types.
/// </summary>
[JsonConverter(typeof(ChartJsTypeConverter))]
public enum ChartJsType {
    /// <summary>
    /// Render a line chart.
    /// </summary>
    Line,
    /// <summary>
    /// Render a bar chart.
    /// </summary>
    Bar,
    /// <summary>
    /// Render a pie chart.
    /// </summary>
    Pie
}

/// <summary>
/// Converts <see cref="ChartJsType"/> values to and from JSON strings.
/// </summary>
public class ChartJsTypeConverter : JsonConverter<ChartJsType> {
    /// <inheritdoc />
    public override ChartJsType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value switch {
            "line" => ChartJsType.Line,
            "bar" => ChartJsType.Bar,
            "pie" => ChartJsType.Pie,
            _ => throw new JsonException()
        };
    }

    /// <inheritdoc />
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
