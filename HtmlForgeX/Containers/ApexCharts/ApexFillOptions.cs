using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents fill configuration options for ApexCharts.
/// </summary>
public class ApexFillOptions {
    /// <summary>
    /// Gets or sets the fill colors.
    /// </summary>
    [JsonPropertyName("colors")]
    public string[]? Colors { get; set; }

    /// <summary>
    /// Gets or sets the opacity.
    /// </summary>
    [JsonPropertyName("opacity")]
    public object? Opacity { get; set; }

    /// <summary>
    /// Gets or sets the fill type.
    /// </summary>
    [JsonPropertyName("type")]
    public object? Type { get; set; }

    /// <summary>
    /// Gets or sets the gradient configuration.
    /// </summary>
    [JsonPropertyName("gradient")]
    public ApexGradient? Gradient { get; set; }

    /// <summary>
    /// Gets or sets the pattern configuration.
    /// </summary>
    [JsonPropertyName("pattern")]
    public ApexPattern? Pattern { get; set; }

    /// <summary>
    /// Sets the fill colors.
    /// </summary>
    public ApexFillOptions SetColors(params string[] colors) {
        Colors = colors;
        return this;
    }

    /// <summary>
    /// Sets the opacity (single value or array).
    /// </summary>
    public ApexFillOptions SetOpacity(object opacity) {
        Opacity = opacity;
        return this;
    }

    /// <summary>
    /// Sets the fill type.
    /// </summary>
    public ApexFillOptions SetType(ApexFillType type) {
        Type = type.ToString().ToLowerInvariant();
        return this;
    }

    /// <summary>
    /// Sets the fill type (for arrays or custom values).
    /// </summary>
    public ApexFillOptions SetType(object type) {
        Type = type;
        return this;
    }

    /// <summary>
    /// Configures the gradient.
    /// </summary>
    public ApexFillOptions SetGradient(System.Action<ApexGradient> configure) {
        Gradient ??= new ApexGradient();
        configure(Gradient);
        return this;
    }

    /// <summary>
    /// Configures the pattern.
    /// </summary>
    public ApexFillOptions SetPattern(System.Action<ApexPattern> configure) {
        Pattern ??= new ApexPattern();
        configure(Pattern);
        return this;
    }
}

/// <summary>
/// Represents gradient configuration.
/// </summary>
public class ApexGradient {
    /// <summary>
    /// Gets or sets the gradient shade.
    /// </summary>
    [JsonPropertyName("shade")]
    [JsonConverter(typeof(ApexEnumConverter<ApexGradientShade>))]
    public ApexGradientShade? Shade { get; set; }

    /// <summary>
    /// Gets or sets the gradient type.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(ApexEnumConverter<ApexGradientType>))]
    public ApexGradientType? Type { get; set; }

    /// <summary>
    /// Gets or sets the shade intensity.
    /// </summary>
    [JsonPropertyName("shadeIntensity")]
    public double? ShadeIntensity { get; set; }

    /// <summary>
    /// Gets or sets the gradient angle.
    /// </summary>
    [JsonPropertyName("gradientToColors")]
    public string[]? GradientToColors { get; set; }

    /// <summary>
    /// Gets or sets the inverse y axis.
    /// </summary>
    [JsonPropertyName("inverseColors")]
    public bool? InverseColors { get; set; }

    /// <summary>
    /// Gets or sets the opacity from.
    /// </summary>
    [JsonPropertyName("opacityFrom")]
    public double? OpacityFrom { get; set; }

    /// <summary>
    /// Gets or sets the opacity to.
    /// </summary>
    [JsonPropertyName("opacityTo")]
    public double? OpacityTo { get; set; }

    /// <summary>
    /// Sets the gradient shade.
    /// </summary>
    public ApexGradient SetShade(ApexGradientShade shade) {
        Shade = shade;
        return this;
    }

    /// <summary>
    /// Sets the gradient type.
    /// </summary>
    public ApexGradient SetType(ApexGradientType type) {
        Type = type;
        return this;
    }

    /// <summary>
    /// Sets the opacity range.
    /// </summary>
    public ApexGradient SetOpacityRange(double from, double to) {
        OpacityFrom = from;
        OpacityTo = to;
        return this;
    }
}

/// <summary>
/// Represents pattern configuration.
/// </summary>
public class ApexPattern {
    /// <summary>
    /// Gets or sets the pattern style.
    /// </summary>
    [JsonPropertyName("style")]
    public object? Style { get; set; }

    /// <summary>
    /// Gets or sets the pattern width.
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    /// <summary>
    /// Gets or sets the pattern height.
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Gets or sets the stroke width.
    /// </summary>
    [JsonPropertyName("strokeWidth")]
    public int? StrokeWidth { get; set; }

    /// <summary>
    /// Sets the pattern style (verticalLines, horizontalLines, slantedLines, squares, circles).
    /// </summary>
    public ApexPattern SetStyle(object style) {
        Style = style;
        return this;
    }

    /// <summary>
    /// Sets the pattern dimensions.
    /// </summary>
    public ApexPattern SetDimensions(int width, int height) {
        Width = width;
        Height = height;
        return this;
    }

    /// <summary>
    /// Sets the stroke width.
    /// </summary>
    public ApexPattern SetStrokeWidth(int width) {
        StrokeWidth = width;
        return this;
    }
}