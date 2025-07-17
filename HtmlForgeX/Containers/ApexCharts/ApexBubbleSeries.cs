using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a collection of bubble data points for a single series.
/// </summary>
public class ApexBubbleSeries {
    /// <summary>
    /// Gets or sets the name of the series.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the list of bubble data points.
    /// </summary>
    [JsonPropertyName("data")]
    public List<ApexBubbleData> Data { get; set; } = new();
}

/// <summary>
/// Represents a single bubble data point.
/// </summary>
public class ApexBubbleData {
    /// <summary>
    /// Gets or sets the X coordinate.
    /// </summary>
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the Y coordinate.
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets the Z value (bubble size).
    /// </summary>
    [JsonPropertyName("z")]
    public double Z { get; set; }
}