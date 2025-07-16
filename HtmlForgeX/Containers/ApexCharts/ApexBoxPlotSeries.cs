using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a collection of boxplot data points for a single series.
/// </summary>
public class ApexBoxPlotSeries {
    /// <summary>
    /// Gets or sets the name of the series.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the list of boxplot data points.
    /// </summary>
    [JsonPropertyName("data")]
    public List<ApexBoxPlotData> Data { get; set; } = new();
}

/// <summary>
/// Represents a single boxplot data point.
/// </summary>
public class ApexBoxPlotData {
    /// <summary>
    /// Gets or sets the X value (category).
    /// </summary>
    [JsonPropertyName("x")]
    public string X { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Y values array: [min, q1, median, q3, max].
    /// </summary>
    [JsonPropertyName("y")]
    public double[] Y { get; set; } = new double[5];
}