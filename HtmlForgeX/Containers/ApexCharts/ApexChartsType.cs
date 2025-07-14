using System.Text.Json.Serialization;
using System.Text.Json;

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
    Mixed
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
            _ => throw new JsonException()
        };

        writer.WriteStringValue(stringValue);
    }
}