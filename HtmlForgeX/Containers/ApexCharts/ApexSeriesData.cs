using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a data series for multi-series charts like Line, Column, Area, etc.
/// </summary>
public class ApexSeriesData {
    /// <summary>
    /// Gets or sets the name of the series.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the list of data points for this series.
    /// </summary>
    [JsonPropertyName("data")]
    public List<object> Data { get; set; } = new();
}