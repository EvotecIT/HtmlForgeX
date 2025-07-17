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
    Pie,
    /// <summary>
    /// Render a radar chart.
    /// </summary>
    Radar,
    /// <summary>
    /// Render a scatter chart.
    /// </summary>
    Scatter,
    /// <summary>
    /// Render a bubble chart.
    /// </summary>
    Bubble,
    /// <summary>
    /// Render a doughnut chart.
    /// </summary>
    Doughnut,
    /// <summary>
    /// Render a polar area chart.
    /// </summary>
    PolarArea,
    /// <summary>
    /// Render a horizontal bar chart.
    /// </summary>
    HorizontalBar,
    /// <summary>
    /// Render a mixed chart.
    /// </summary>
    Mixed
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
            "radar" => ChartJsType.Radar,
            "scatter" => ChartJsType.Scatter,
            "bubble" => ChartJsType.Bubble,
            "doughnut" => ChartJsType.Doughnut,
            "polarArea" => ChartJsType.PolarArea,
            "horizontalBar" => ChartJsType.HorizontalBar,
            _ => throw new JsonException()
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, ChartJsType value, JsonSerializerOptions options) {
        var stringValue = value switch {
            ChartJsType.Line => "line",
            ChartJsType.Bar => "bar",
            ChartJsType.Pie => "pie",
            ChartJsType.Radar => "radar",
            ChartJsType.Scatter => "scatter",
            ChartJsType.Bubble => "bubble",
            ChartJsType.Doughnut => "doughnut",
            ChartJsType.PolarArea => "polarArea",
            ChartJsType.HorizontalBar => "bar",
            _ => throw new JsonException()
        };
        writer.WriteStringValue(stringValue);
    }
}
