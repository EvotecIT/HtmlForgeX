using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Container for per-chart-type plot options.
/// </summary>
public class ApexPlotOptions {
    /// <summary>
    /// Gets or sets heatmap specific configuration.
    /// </summary>
    [JsonPropertyName("heatmap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexHeatmapOptions? Heatmap { get; set; }

    /// <summary>
    /// Configures heatmap options via a delegate.
    /// </summary>
    /// <param name="configure">Delegate used to configure heatmap options.</param>
    /// <returns>The current <see cref="ApexPlotOptions"/> instance.</returns>
    public ApexPlotOptions HeatmapOptions(Action<ApexHeatmapOptions> configure) {
        Heatmap ??= new ApexHeatmapOptions();
        configure(Heatmap);
        return this;
    }
}
