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
    /// Gets or sets bar specific configuration.
    /// </summary>
    [JsonPropertyName("bar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexBarOptions? Bar { get; set; }

    /// <summary>
    /// Gets or sets pie specific configuration.
    /// </summary>
    [JsonPropertyName("pie")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexPieOptions? Pie { get; set; }

    /// <summary>
    /// Gets or sets radial bar specific configuration.
    /// </summary>
    [JsonPropertyName("radialBar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexRadialBarOptions? RadialBar { get; set; }

    /// <summary>
    /// Gets or sets radar specific configuration.
    /// </summary>
    [JsonPropertyName("radar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexRadarOptions? Radar { get; set; }

    /// <summary>
    /// Gets or sets boxplot specific configuration.
    /// </summary>
    [JsonPropertyName("boxPlot")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexBoxPlotOptions? BoxPlot { get; set; }

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

    /// <summary>
    /// Configures bar-specific options.
    /// </summary>
    /// <param name="configure">Delegate used to configure bar options.</param>
    /// <returns>The current <see cref="ApexPlotOptions"/> instance.</returns>
    public ApexPlotOptions BarOptions(Action<ApexBarOptions> configure) {
        Bar ??= new ApexBarOptions();
        configure(Bar);
        return this;
    }

    /// <summary>
    /// Configures pie-specific options.
    /// </summary>
    /// <param name="configure">Delegate used to configure pie options.</param>
    /// <returns>The current <see cref="ApexPlotOptions"/> instance.</returns>
    public ApexPlotOptions PieOptions(Action<ApexPieOptions> configure) {
        Pie ??= new ApexPieOptions();
        configure(Pie);
        return this;
    }

    /// <summary>
    /// Configures radial bar options.
    /// </summary>
    /// <param name="configure">Delegate used to configure radial bar options.</param>
    /// <returns>The current <see cref="ApexPlotOptions"/> instance.</returns>
    public ApexPlotOptions RadialBarOptions(Action<ApexRadialBarOptions> configure) {
        RadialBar ??= new ApexRadialBarOptions();
        configure(RadialBar);
        return this;
    }

    /// <summary>
    /// Configures radar options.
    /// </summary>
    /// <param name="configure">Delegate used to configure radar options.</param>
    /// <returns>The current <see cref="ApexPlotOptions"/> instance.</returns>
    public ApexPlotOptions RadarOptions(Action<ApexRadarOptions> configure) {
        Radar ??= new ApexRadarOptions();
        configure(Radar);
        return this;
    }

    /// <summary>
    /// Configures boxplot options.
    /// </summary>
    /// <param name="configure">Delegate used to configure boxplot options.</param>
    /// <returns>The current <see cref="ApexPlotOptions"/> instance.</returns>
    public ApexPlotOptions BoxPlotOptions(Action<ApexBoxPlotOptions> configure) {
        BoxPlot ??= new ApexBoxPlotOptions();
        configure(BoxPlot);
        return this;
    }
}