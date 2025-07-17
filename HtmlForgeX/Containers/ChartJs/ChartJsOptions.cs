using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents the options configuration for a Chart.js chart.
/// </summary>
public class ChartJsOptions {
    /// <summary>
    /// Gets or sets whether the chart is responsive.
    /// </summary>
    [JsonPropertyName("responsive")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Responsive { get; set; }

    /// <summary>
    /// Gets or sets whether to maintain aspect ratio.
    /// </summary>
    [JsonPropertyName("maintainAspectRatio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MaintainAspectRatio { get; set; }

    /// <summary>
    /// Gets or sets the aspect ratio.
    /// </summary>
    [JsonPropertyName("aspectRatio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AspectRatio { get; set; }

    /// <summary>
    /// Gets or sets the plugins configuration.
    /// </summary>
    [JsonPropertyName("plugins")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsPlugins? Plugins { get; set; }

    /// <summary>
    /// Gets or sets the scales configuration.
    /// </summary>
    [JsonPropertyName("scales")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsScales? Scales { get; set; }

    /// <summary>
    /// Gets or sets the animation configuration.
    /// </summary>
    [JsonPropertyName("animation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Animation { get; set; }

    /// <summary>
    /// Gets or sets the interaction configuration.
    /// </summary>
    [JsonPropertyName("interaction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsInteraction? Interaction { get; set; }

    /// <summary>
    /// Gets or sets the layout configuration.
    /// </summary>
    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsLayout? Layout { get; set; }

    /// <summary>
    /// Gets or sets additional properties for extensibility.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? ExtensionData { get; set; }
}

/// <summary>
/// Represents the plugins configuration for a Chart.js chart.
/// </summary>
public class ChartJsPlugins {
    /// <summary>
    /// Gets or sets the legend configuration.
    /// </summary>
    [JsonPropertyName("legend")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsLegend? Legend { get; set; }

    /// <summary>
    /// Gets or sets the title configuration.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsTitle? Title { get; set; }

    /// <summary>
    /// Gets or sets the tooltip configuration.
    /// </summary>
    [JsonPropertyName("tooltip")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsTooltip? Tooltip { get; set; }

    /// <summary>
    /// Gets or sets additional properties for extensibility.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? ExtensionData { get; set; }
}

/// <summary>
/// Represents the legend configuration for a Chart.js chart.
/// </summary>
public class ChartJsLegend {
    /// <summary>
    /// Gets or sets whether to display the legend.
    /// </summary>
    [JsonPropertyName("display")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Display { get; set; }

    /// <summary>
    /// Gets or sets the position of the legend.
    /// </summary>
    [JsonPropertyName("position")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(ChartJsPositionNullableConverter))]
    public ChartJsPosition? Position { get; set; }

    /// <summary>
    /// Gets or sets the alignment of the legend.
    /// </summary>
    [JsonPropertyName("align")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(ChartJsAlignNullableConverter))]
    public ChartJsAlign? Align { get; set; }

    /// <summary>
    /// Gets or sets the labels configuration.
    /// </summary>
    [JsonPropertyName("labels")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsLegendLabels? Labels { get; set; }
}

/// <summary>
/// Represents the legend labels configuration.
/// </summary>
public class ChartJsLegendLabels {
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
    /// Gets or sets whether to use point style.
    /// </summary>
    [JsonPropertyName("usePointStyle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UsePointStyle { get; set; }
}

/// <summary>
/// Represents the title configuration for a Chart.js chart.
/// </summary>
public class ChartJsTitle {
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
    public object? Text { get; set; }

    /// <summary>
    /// Gets or sets the position of the title.
    /// </summary>
    [JsonPropertyName("position")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(ChartJsPositionNullableConverter))]
    public ChartJsPosition? Position { get; set; }

    /// <summary>
    /// Gets or sets the font configuration.
    /// </summary>
    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartJsFont? Font { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the padding.
    /// </summary>
    [JsonPropertyName("padding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Padding { get; set; }
}

/// <summary>
/// Represents the font configuration.
/// </summary>
public class ChartJsFont {
    /// <summary>
    /// Gets or sets the font size.
    /// </summary>
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }

    /// <summary>
    /// Gets or sets the font family.
    /// </summary>
    [JsonPropertyName("family")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Family { get; set; }

    /// <summary>
    /// Gets or sets the font style.
    /// </summary>
    [JsonPropertyName("style")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(ChartJsFontStyleConverter))]
    public ChartJsFontStyle? Style { get; set; }

    /// <summary>
    /// Gets or sets the font weight.
    /// </summary>
    [JsonPropertyName("weight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Weight { get; set; }

    /// <summary>
    /// Gets or sets the line height.
    /// </summary>
    [JsonPropertyName("lineHeight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? LineHeight { get; set; }
}

/// <summary>
/// Represents the tooltip configuration.
/// </summary>
public class ChartJsTooltip {
    /// <summary>
    /// Gets or sets whether to enable tooltips.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the mode.
    /// </summary>
    [JsonPropertyName("mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(ChartJsInteractionModeNullableConverter))]
    public ChartJsInteractionMode? Mode { get; set; }

    /// <summary>
    /// Gets or sets whether to intersect.
    /// </summary>
    [JsonPropertyName("intersect")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Intersect { get; set; }

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    [JsonPropertyName("backgroundColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the title color.
    /// </summary>
    [JsonPropertyName("titleColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TitleColor { get; set; }

    /// <summary>
    /// Gets or sets the body color.
    /// </summary>
    [JsonPropertyName("bodyColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BodyColor { get; set; }

    /// <summary>
    /// Gets or sets the border color.
    /// </summary>
    [JsonPropertyName("borderColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BorderColor { get; set; }

    /// <summary>
    /// Gets or sets the border width.
    /// </summary>
    [JsonPropertyName("borderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BorderWidth { get; set; }
}

/// <summary>
/// Represents the interaction configuration.
/// </summary>
public class ChartJsInteraction {
    /// <summary>
    /// Gets or sets the mode.
    /// </summary>
    [JsonPropertyName("mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(ChartJsInteractionModeNullableConverter))]
    public ChartJsInteractionMode? Mode { get; set; }

    /// <summary>
    /// Gets or sets whether to intersect.
    /// </summary>
    [JsonPropertyName("intersect")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Intersect { get; set; }

    /// <summary>
    /// Gets or sets the axis.
    /// </summary>
    [JsonPropertyName("axis")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Axis { get; set; }
}

/// <summary>
/// Represents the layout configuration.
/// </summary>
public class ChartJsLayout {
    /// <summary>
    /// Gets or sets the padding.
    /// </summary>
    [JsonPropertyName("padding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Padding { get; set; }
}