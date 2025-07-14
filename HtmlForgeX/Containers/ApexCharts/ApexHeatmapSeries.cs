using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a collection of data points for a single heatmap series.
/// </summary>
public class ApexHeatmapSeries {
    /// <summary>
    /// Gets or sets the name of the series.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the list of <see cref="ApexHeatmapData"/> points belonging to this series.
    /// </summary>
    [JsonPropertyName("data")]
    public List<ApexHeatmapData> Data { get; set; } = new();
}
