using System.Collections.Generic;
using System.Linq;
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

    #region Fluent API Methods

    /// <summary>
    /// Sets the label for the dataset.
    /// </summary>
    public ChartJsDataset SetLabel(string label) {
        Label = label;
        return this;
    }

    /// <summary>
    /// Sets the data points for the dataset.
    /// </summary>
    public ChartJsDataset SetData(params double[] values) {
        Data = new List<double>(values);
        return this;
    }

    /// <summary>
    /// Sets the data points for the dataset.
    /// </summary>
    public ChartJsDataset SetData(IEnumerable<double> values) {
        Data = values.ToList();
        return this;
    }

    /// <summary>
    /// Sets the background color using a string.
    /// </summary>
    public ChartJsDataset SetBackgroundColor(string color) {
        BackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets the background color using RGBColor.
    /// </summary>
    public ChartJsDataset SetBackgroundColor(RGBColor color) {
        BackgroundColor = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets multiple background colors using strings.
    /// </summary>
    public ChartJsDataset SetBackgroundColors(params string[] colors) {
        BackgroundColor = colors;
        return this;
    }

    /// <summary>
    /// Sets multiple background colors using RGBColor.
    /// </summary>
    public ChartJsDataset SetBackgroundColors(params RGBColor[] colors) {
        BackgroundColor = colors.Select(c => c.ToString()).ToArray();
        return this;
    }

    /// <summary>
    /// Sets the border color using a string.
    /// </summary>
    public ChartJsDataset SetBorderColor(string color) {
        BorderColor = color;
        return this;
    }

    /// <summary>
    /// Sets the border color using RGBColor.
    /// </summary>
    public ChartJsDataset SetBorderColor(RGBColor color) {
        BorderColor = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets multiple border colors using strings.
    /// </summary>
    public ChartJsDataset SetBorderColors(params string[] colors) {
        BorderColor = colors;
        return this;
    }

    /// <summary>
    /// Sets multiple border colors using RGBColor.
    /// </summary>
    public ChartJsDataset SetBorderColors(params RGBColor[] colors) {
        BorderColor = colors.Select(c => c.ToString()).ToArray();
        return this;
    }

    /// <summary>
    /// Sets the border width.
    /// </summary>
    public ChartJsDataset SetBorderWidth(int width) {
        BorderWidth = width;
        return this;
    }

    /// <summary>
    /// Sets the point radius.
    /// </summary>
    public ChartJsDataset SetPointRadius(int radius) {
        PointRadius = radius;
        return this;
    }

    /// <summary>
    /// Sets the point background color using a string.
    /// </summary>
    public ChartJsDataset SetPointBackgroundColor(string color) {
        PointBackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets the point background color using RGBColor.
    /// </summary>
    public ChartJsDataset SetPointBackgroundColor(RGBColor color) {
        PointBackgroundColor = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the point border color using a string.
    /// </summary>
    public ChartJsDataset SetPointBorderColor(string color) {
        PointBorderColor = color;
        return this;
    }

    /// <summary>
    /// Sets the point border color using RGBColor.
    /// </summary>
    public ChartJsDataset SetPointBorderColor(RGBColor color) {
        PointBorderColor = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the point border width.
    /// </summary>
    public ChartJsDataset SetPointBorderWidth(int width) {
        PointBorderWidth = width;
        return this;
    }

    /// <summary>
    /// Sets the point hover radius.
    /// </summary>
    public ChartJsDataset SetPointHoverRadius(int radius) {
        PointHoverRadius = radius;
        return this;
    }

    /// <summary>
    /// Sets the point hover background color using a string.
    /// </summary>
    public ChartJsDataset SetPointHoverBackgroundColor(string color) {
        PointHoverBackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets the point hover background color using RGBColor.
    /// </summary>
    public ChartJsDataset SetPointHoverBackgroundColor(RGBColor color) {
        PointHoverBackgroundColor = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the point hover border color using a string.
    /// </summary>
    public ChartJsDataset SetPointHoverBorderColor(string color) {
        PointHoverBorderColor = color;
        return this;
    }

    /// <summary>
    /// Sets the point hover border color using RGBColor.
    /// </summary>
    public ChartJsDataset SetPointHoverBorderColor(RGBColor color) {
        PointHoverBorderColor = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the point hover border width.
    /// </summary>
    public ChartJsDataset SetPointHoverBorderWidth(int width) {
        PointHoverBorderWidth = width;
        return this;
    }

    /// <summary>
    /// Sets the line tension for curved lines.
    /// </summary>
    public ChartJsDataset SetTension(double tension) {
        Tension = tension;
        return this;
    }

    /// <summary>
    /// Sets whether to fill the area under the line.
    /// </summary>
    public ChartJsDataset SetFill(bool fill) {
        Fill = fill;
        return this;
    }

    /// <summary>
    /// Sets advanced fill options.
    /// </summary>
    public ChartJsDataset SetFill(string fill) {
        Fill = fill;
        return this;
    }

    /// <summary>
    /// Sets whether to show the line (for scatter plots).
    /// </summary>
    public ChartJsDataset SetShowLine(bool show) {
        ShowLine = show;
        return this;
    }

    /// <summary>
    /// Sets the border dash pattern.
    /// </summary>
    public ChartJsDataset SetBorderDash(params int[] pattern) {
        BorderDash = new List<int>(pattern);
        return this;
    }

    /// <summary>
    /// Sets the chart type for mixed charts.
    /// </summary>
    public ChartJsDataset SetType(string type) {
        Type = type;
        return this;
    }

    /// <summary>
    /// Sets the Y axis ID.
    /// </summary>
    public ChartJsDataset SetYAxisID(string id) {
        YAxisID = id;
        return this;
    }

    /// <summary>
    /// Sets whether the dataset is hidden.
    /// </summary>
    public ChartJsDataset SetHidden(bool hidden) {
        Hidden = hidden;
        return this;
    }

    /// <summary>
    /// Sets the stack group for stacked charts.
    /// </summary>
    public ChartJsDataset SetStack(string stack) {
        Stack = stack;
        return this;
    }

    #endregion
}