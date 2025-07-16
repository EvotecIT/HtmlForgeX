using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents bar chart specific options.
/// </summary>
public class ApexBarOptions {
    /// <summary>
    /// Gets or sets whether the bar chart is horizontal.
    /// </summary>
    [JsonPropertyName("horizontal")]
    public bool? Horizontal { get; set; }

    /// <summary>
    /// Gets or sets the border radius.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public int? BorderRadius { get; set; }

    /// <summary>
    /// Gets or sets the column width percentage.
    /// </summary>
    [JsonPropertyName("columnWidth")]
    public string? ColumnWidth { get; set; }

    /// <summary>
    /// Gets or sets the bar height percentage.
    /// </summary>
    [JsonPropertyName("barHeight")]
    public string? BarHeight { get; set; }

    /// <summary>
    /// Gets or sets whether bars are distributed.
    /// </summary>
    [JsonPropertyName("distributed")]
    public bool? Distributed { get; set; }

    /// <summary>
    /// Gets or sets the data labels position.
    /// </summary>
    [JsonPropertyName("dataLabels")]
    public ApexBarDataLabels? DataLabels { get; set; }

    /// <summary>
    /// Gets or sets whether this is a funnel chart.
    /// </summary>
    [JsonPropertyName("isFunnel")]
    public bool? IsFunnelChart { get; set; }

    /// <summary>
    /// Sets whether the bar chart is horizontal.
    /// </summary>
    public ApexBarOptions HorizontalValue(bool horizontal) {
        Horizontal = horizontal;
        return this;
    }

    /// <summary>
    /// Sets the border radius.
    /// </summary>
    public ApexBarOptions BorderRadiusValue(int radius) {
        BorderRadius = radius;
        return this;
    }

    /// <summary>
    /// Sets the column width.
    /// </summary>
    public ApexBarOptions ColumnWidthValue(string width) {
        ColumnWidth = width;
        return this;
    }

    /// <summary>
    /// Sets the bar height.
    /// </summary>
    public ApexBarOptions BarHeightValue(string height) {
        BarHeight = height;
        return this;
    }

    /// <summary>
    /// Sets whether bars are distributed.
    /// </summary>
    public ApexBarOptions DistributedValue(bool distributed) {
        Distributed = distributed;
        return this;
    }

    /// <summary>
    /// Sets whether this is a funnel chart.
    /// </summary>
    public ApexBarOptions IsFunnel(bool isFunnel) {
        IsFunnelChart = isFunnel;
        return this;
    }
}

/// <summary>
/// Represents bar data labels configuration.
/// </summary>
public class ApexBarDataLabels {
    /// <summary>
    /// Gets or sets the position.
    /// </summary>
    [JsonPropertyName("position")]
    public string? Position { get; set; }
}