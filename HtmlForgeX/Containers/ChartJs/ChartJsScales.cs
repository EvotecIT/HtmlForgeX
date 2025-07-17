using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents the scales configuration for a Chart.js chart.
/// </summary>
public class ChartJsScales {
    /// <summary>
    /// Gets or sets the x-axis configuration.
    /// </summary>
    [JsonPropertyName("x")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsAxis? X { get; set; }

    /// <summary>
    /// Gets or sets the y-axis configuration.
    /// </summary>
    [JsonPropertyName("y")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsAxis? Y { get; set; }

    /// <summary>
    /// Gets or sets the radial axis configuration (for radar/polar charts).
    /// </summary>
    [JsonPropertyName("r")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsAxis? R { get; set; }

    /// <summary>
    /// Gets or sets additional axes.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? ExtensionData { get; set; }
}

/// <summary>
/// Represents an axis configuration.
/// </summary>
public class ChartJsAxis {
    /// <summary>
    /// Gets or sets the type of scale.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets whether the axis is displayed.
    /// </summary>
    [JsonPropertyName("display")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Display { get; set; }

    /// <summary>
    /// Gets or sets the position of the axis.
    /// </summary>
    [JsonPropertyName("position")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Position { get; set; }

    /// <summary>
    /// Gets or sets whether the scale should begin at zero.
    /// </summary>
    [JsonPropertyName("beginAtZero")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BeginAtZero { get; set; }

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [JsonPropertyName("min")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Min { get; set; }

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [JsonPropertyName("max")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Max { get; set; }

    /// <summary>
    /// Gets or sets the suggested minimum value.
    /// </summary>
    [JsonPropertyName("suggestedMin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SuggestedMin { get; set; }

    /// <summary>
    /// Gets or sets the suggested maximum value.
    /// </summary>
    [JsonPropertyName("suggestedMax")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SuggestedMax { get; set; }

    /// <summary>
    /// Gets or sets whether the axis is stacked.
    /// </summary>
    [JsonPropertyName("stacked")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Stacked { get; set; }

    /// <summary>
    /// Gets or sets the title configuration.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsAxisTitle? Title { get; set; }

    /// <summary>
    /// Gets or sets the grid configuration.
    /// </summary>
    [JsonPropertyName("grid")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsGrid? Grid { get; set; }

    /// <summary>
    /// Gets or sets the ticks configuration.
    /// </summary>
    [JsonPropertyName("ticks")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsTicks? Ticks { get; set; }
}

/// <summary>
/// Represents the axis title configuration.
/// </summary>
public class ChartJsAxisTitle {
    /// <summary>
    /// Gets or sets whether to display the title.
    /// </summary>
    [JsonPropertyName("display")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Display { get; set; }

    /// <summary>
    /// Gets or sets the title text.
    /// </summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the font configuration.
    /// </summary>
    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsFont? Font { get; set; }

    /// <summary>
    /// Gets or sets the padding.
    /// </summary>
    [JsonPropertyName("padding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Padding { get; set; }
}

/// <summary>
/// Represents the grid configuration.
/// </summary>
public class ChartJsGrid {
    /// <summary>
    /// Gets or sets whether to display grid lines.
    /// </summary>
    [JsonPropertyName("display")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Display { get; set; }

    /// <summary>
    /// Gets or sets the color of grid lines.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Color { get; set; }

    /// <summary>
    /// Gets or sets the width of grid lines.
    /// </summary>
    [JsonPropertyName("lineWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? LineWidth { get; set; }

    /// <summary>
    /// Gets or sets whether to draw border.
    /// </summary>
    [JsonPropertyName("drawBorder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DrawBorder { get; set; }

    /// <summary>
    /// Gets or sets whether to draw on chart area.
    /// </summary>
    [JsonPropertyName("drawOnChartArea")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DrawOnChartArea { get; set; }

    /// <summary>
    /// Gets or sets whether to draw ticks.
    /// </summary>
    [JsonPropertyName("drawTicks")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DrawTicks { get; set; }
}

/// <summary>
/// Represents the ticks configuration.
/// </summary>
public class ChartJsTicks {
    /// <summary>
    /// Gets or sets whether to display ticks.
    /// </summary>
    [JsonPropertyName("display")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Display { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the font configuration.
    /// </summary>
    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsFont? Font { get; set; }

    /// <summary>
    /// Gets or sets the padding.
    /// </summary>
    [JsonPropertyName("padding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Padding { get; set; }

    /// <summary>
    /// Gets or sets the step size.
    /// </summary>
    [JsonPropertyName("stepSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? StepSize { get; set; }

    /// <summary>
    /// Gets or sets whether to begin at zero.
    /// </summary>
    [JsonPropertyName("beginAtZero")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BeginAtZero { get; set; }

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [JsonPropertyName("min")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Min { get; set; }

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [JsonPropertyName("max")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Max { get; set; }
}