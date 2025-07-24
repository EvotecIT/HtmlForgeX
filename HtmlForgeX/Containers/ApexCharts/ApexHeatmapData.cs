using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a single point within a heatmap series.
/// </summary>
public class ApexHeatmapData {
    /// <summary>
    /// Gets or sets the X axis value for the heatmap point.
    /// </summary>
    [JsonPropertyName("x")]
    public string X { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Y axis value for the heatmap point.
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }
}