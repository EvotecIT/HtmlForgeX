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
    /// Gets or sets the legend position.
    /// </summary>
    [JsonPropertyName("position")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(ApexEnumConverter<ApexPosition>))]
    public ApexPosition? LegendPosition { get; set; }

    /// <summary>
    /// Gets or sets whether the legend is floating.
    /// </summary>
    [JsonPropertyName("floating")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Floating { get; set; }

    /// <summary>
    /// Gets or sets the horizontal alignment.
    /// </summary>
    [JsonPropertyName("horizontalAlign")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HorizontalAlign { get; set; }

    /// <summary>
    /// Gets or sets the font size.
    /// </summary>
    [JsonPropertyName("fontSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FontSize { get; set; }

    /// <summary>
    /// Enables or disables the legend.
    /// </summary>
    /// <param name="value">Whether to show the legend.</param>
    /// <returns>The current <see cref="ApexLegendOptions"/> instance.</returns>
    public ApexLegendOptions ShowLegend(bool value) {
        Show = value;
        return this;
    }

    /// <summary>
    /// Sets the legend position.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <returns>The current <see cref="ApexLegendOptions"/> instance.</returns>
    public ApexLegendOptions Position(ApexPosition position) {
        LegendPosition = position;
        return this;
    }

    /// <summary>
    /// Sets whether the legend is floating.
    /// </summary>
    /// <param name="floating">Whether the legend should float.</param>
    /// <returns>The current <see cref="ApexLegendOptions"/> instance.</returns>
    public ApexLegendOptions SetFloating(bool floating) {
        Floating = floating;
        return this;
    }

    /// <summary>
    /// Sets the horizontal alignment.
    /// </summary>
    /// <param name="align">The alignment (center, left, right).</param>
    /// <returns>The current <see cref="ApexLegendOptions"/> instance.</returns>
    public ApexLegendOptions SetHorizontalAlign(string align) {
        HorizontalAlign = align;
        return this;
    }

    /// <summary>
    /// Sets the font size.
    /// </summary>
    /// <param name="size">The font size.</param>
    /// <returns>The current <see cref="ApexLegendOptions"/> instance.</returns>
    public ApexLegendOptions SetFontSize(string size) {
        FontSize = size;
        return this;
    }
}
