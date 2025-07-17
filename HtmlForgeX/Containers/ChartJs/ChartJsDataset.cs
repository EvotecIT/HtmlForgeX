using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a dataset in a Chart.js chart with full configuration options.
/// </summary>
public class ChartJsDataset {
    /// <summary>
    /// Gets or sets the label for the dataset.
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; set; } = "Dataset";

    /// <summary>
    /// Gets or sets the data points for standard charts (line, bar, etc).
    /// </summary>
    [JsonIgnore]
    public List<double>? Data { get; set; }

    /// <summary>
    /// Gets or sets the scatter/bubble data points.
    /// </summary>
    [JsonIgnore]
    public List<object>? PointData { get; set; }
    
    /// <summary>
    /// Gets the data for JSON serialization (returns either Data or PointData).
    /// </summary>
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? JsonData => PointData ?? (object?)Data;

    /// <summary>
    /// Gets or sets the background color(s).
    /// </summary>
    [JsonPropertyName("backgroundColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? BackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the border color(s).
    /// </summary>
    [JsonPropertyName("borderColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? BorderColor { get; set; }

    /// <summary>
    /// Gets or sets the border width.
    /// </summary>
    [JsonPropertyName("borderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BorderWidth { get; set; }

    /// <summary>
    /// Gets or sets the point background color(s).
    /// </summary>
    [JsonPropertyName("pointBackgroundColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? PointBackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the point border color(s).
    /// </summary>
    [JsonPropertyName("pointBorderColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? PointBorderColor { get; set; }

    /// <summary>
    /// Gets or sets the point hover background color(s).
    /// </summary>
    [JsonPropertyName("pointHoverBackgroundColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? PointHoverBackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the point hover border color(s).
    /// </summary>
    [JsonPropertyName("pointHoverBorderColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? PointHoverBorderColor { get; set; }

    /// <summary>
    /// Gets or sets the point radius.
    /// </summary>
    [JsonPropertyName("pointRadius")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PointRadius { get; set; }

    /// <summary>
    /// Gets or sets the point hover radius.
    /// </summary>
    [JsonPropertyName("pointHoverRadius")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PointHoverRadius { get; set; }

    /// <summary>
    /// Gets or sets the point border width.
    /// </summary>
    [JsonPropertyName("pointBorderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PointBorderWidth { get; set; }

    /// <summary>
    /// Gets or sets the point hover border width.
    /// </summary>
    [JsonPropertyName("pointHoverBorderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PointHoverBorderWidth { get; set; }

    /// <summary>
    /// Gets or sets the fill mode.
    /// </summary>
    [JsonPropertyName("fill")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Fill { get; set; }

    /// <summary>
    /// Gets or sets the line tension (for curved lines).
    /// </summary>
    [JsonPropertyName("tension")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Tension { get; set; }

    /// <summary>
    /// Gets or sets whether to show the line.
    /// </summary>
    [JsonPropertyName("showLine")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowLine { get; set; }

    /// <summary>
    /// Gets or sets the border dash pattern.
    /// </summary>
    [JsonPropertyName("borderDash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<int>? BorderDash { get; set; }

    /// <summary>
    /// Gets or sets the type of chart for mixed charts.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the Y axis ID.
    /// </summary>
    [JsonPropertyName("yAxisID")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? YAxisID { get; set; }

    /// <summary>
    /// Gets or sets whether this dataset is hidden.
    /// </summary>
    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hidden { get; set; }

    /// <summary>
    /// Gets or sets the stack group for stacked charts.
    /// </summary>
    [JsonPropertyName("stack")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Stack { get; set; }

    /// <summary>
    /// Gets or sets additional properties for extensibility.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? ExtensionData { get; set; }
}