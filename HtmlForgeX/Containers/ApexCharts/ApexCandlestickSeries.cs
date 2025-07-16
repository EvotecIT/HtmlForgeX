using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a collection of candlestick data points for a single series.
/// </summary>
public class ApexCandlestickSeries {
    /// <summary>
    /// Gets or sets the name of the series.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the list of candlestick data points.
    /// </summary>
    [JsonPropertyName("data")]
    public List<ApexCandlestickData> Data { get; set; } = new();
}

/// <summary>
/// Represents a single candlestick data point.
/// </summary>
public class ApexCandlestickData {
    /// <summary>
    /// Gets or sets the X value (typically date/time).
    /// </summary>
    [JsonPropertyName("x")]
    public string X { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Y values array: [open, high, low, close].
    /// </summary>
    [JsonPropertyName("y")]
    public double[] Y { get; set; } = new double[4];
}