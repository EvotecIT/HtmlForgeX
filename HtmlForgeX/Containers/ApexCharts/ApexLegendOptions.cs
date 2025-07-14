using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Options controlling the chart legend display when rendering ApexCharts
/// graphs.
/// </summary>
public class ApexLegendOptions {
    /// <summary>
    /// Gets or sets a value indicating whether the legend is visible.
    /// </summary>
    [JsonPropertyName("show")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Show { get; set; }

    /// <summary>
    /// Enables or disables the legend.
    /// </summary>
    /// <param name="value">Whether to show the legend.</param>
    /// <returns>The current <see cref="ApexLegendOptions"/> instance.</returns>
    public ApexLegendOptions ShowLegend(bool value) {
        Show = value;
        return this;
    }
}
