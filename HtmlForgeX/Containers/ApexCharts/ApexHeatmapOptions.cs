using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Configuration options specific to heatmap charts.
/// </summary>
public class ApexHeatmapOptions {
    /// <summary>
    /// Gets or sets the radius applied to heatmap points.
    /// </summary>
    [JsonPropertyName("radius")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Radius { get; set; }

    /// <summary>
    /// Sets the radius value for the heatmap points.
    /// </summary>
    /// <param name="radius">Radius of each point.</param>
    /// <returns>The current <see cref="ApexHeatmapOptions"/> instance.</returns>
    public ApexHeatmapOptions RadiusValue(double radius) {
        Radius = radius;
        return this;
    }
}