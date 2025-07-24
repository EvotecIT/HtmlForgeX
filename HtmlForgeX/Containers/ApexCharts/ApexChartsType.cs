using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Supported ApexChart chart types.
/// </summary>
[JsonConverter(typeof(ApexChartTypeConverter))]
public enum ApexChartType {
    /// <summary>Pie chart.</summary>
    Pie,
    /// <summary>Donut chart.</summary>
    Donut,
    /// <summary>Bar chart.</summary>
    Bar,
    /// <summary>Radial bar chart.</summary>
    RadialBar,
    /// <summary>Area chart.</summary>
    Area,
    /// <summary>Treemap chart.</summary>
    Treemap,
    /// <summary>Heatmap chart.</summary>
    Heatmap,
    /// <summary>Radar chart.</summary>
    Radar,
    /// <summary>Mixed chart.</summary>
    Mixed,
    /// <summary>Line chart.</summary>
    Line,
    /// <summary>Column chart.</summary>
    Column,
    /// <summary>Scatter chart.</summary>
    Scatter,
    /// <summary>Bubble chart.</summary>
    Bubble,
    /// <summary>Candlestick chart.</summary>
    Candlestick,
    /// <summary>BoxPlot chart.</summary>
    BoxPlot,
    /// <summary>Range bar chart.</summary>
    RangeBar,
    /// <summary>Range area chart.</summary>
    RangeArea,
    /// <summary>Funnel chart.</summary>
    Funnel,
    /// <summary>Polar area chart.</summary>
    PolarArea
}

/// <summary>
/// JSON converter used to serialize <see cref="ApexChartType"/> values.
/// </summary>
public class ApexChartTypeConverter : JsonConverter<ApexChartType> {
    /// <inheritdoc />
    public override ApexChartType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();

        return value switch {
            "pie" => ApexChartType.Pie,
            "donut" => ApexChartType.Donut,
            "bar" => ApexChartType.Bar,
            "radialBar" => ApexChartType.RadialBar,
            "area" => ApexChartType.Area,
            "treemap" => ApexChartType.Treemap,
            "heatmap" => ApexChartType.Heatmap,
            "radar" => ApexChartType.Radar,
            "mixed" => ApexChartType.Mixed,
            "line" => ApexChartType.Line,
            "column" => ApexChartType.Column,
            "scatter" => ApexChartType.Scatter,
            "bubble" => ApexChartType.Bubble,
            "candlestick" => ApexChartType.Candlestick,
            "boxPlot" => ApexChartType.BoxPlot,
            "rangeBar" => ApexChartType.RangeBar,
            "rangeArea" => ApexChartType.RangeArea,
            "funnel" => ApexChartType.Funnel,
            "polarArea" => ApexChartType.PolarArea,
            _ => throw new JsonException()
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, ApexChartType value, JsonSerializerOptions options) {
        var stringValue = value switch {
            ApexChartType.Pie => "pie",
            ApexChartType.Donut => "donut",
            ApexChartType.Bar => "bar",
            ApexChartType.RadialBar => "radialBar",
            ApexChartType.Area => "area",
            ApexChartType.Treemap => "treemap",
            ApexChartType.Heatmap => "heatmap",
            ApexChartType.Radar => "radar",
            ApexChartType.Mixed => "mixed",
            ApexChartType.Line => "line",
            ApexChartType.Column => "column",
            ApexChartType.Scatter => "scatter",
            ApexChartType.Bubble => "bubble",
            ApexChartType.Candlestick => "candlestick",
            ApexChartType.BoxPlot => "boxPlot",
            ApexChartType.RangeBar => "rangeBar",
            ApexChartType.RangeArea => "rangeArea",
            ApexChartType.Funnel => "funnel",
            ApexChartType.PolarArea => "polarArea",
            _ => throw new JsonException()
        };

        writer.WriteStringValue(stringValue);
    }
}