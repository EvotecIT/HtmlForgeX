using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents axis configuration options for ApexCharts.
/// </summary>
public class ApexAxisOptions {
    /// <summary>
    /// Gets or sets whether to show the axis.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }

    /// <summary>
    /// Gets or sets the axis type.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(ApexEnumConverter<ApexAxisType>))]
    public ApexAxisType? Type { get; set; }

    /// <summary>
    /// Gets or sets the categories for the axis.
    /// </summary>
    [JsonPropertyName("categories")]
    public string[]? Categories { get; set; }

    /// <summary>
    /// Gets or sets the title configuration.
    /// </summary>
    [JsonPropertyName("title")]
    public ApexAxisTitle? Title { get; set; }

    /// <summary>
    /// Gets or sets the labels configuration.
    /// </summary>
    [JsonPropertyName("labels")]
    public ApexAxisLabels? Labels { get; set; }

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [JsonPropertyName("min")]
    public double? Min { get; set; }

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [JsonPropertyName("max")]
    public double? Max { get; set; }

    /// <summary>
    /// Sets whether to show the axis.
    /// </summary>
    public ApexAxisOptions ShowAxis(bool show) {
        Show = show;
        return this;
    }

    /// <summary>
    /// Sets the axis type.
    /// </summary>
    public ApexAxisOptions AxisType(ApexAxisType type) {
        Type = type;
        return this;
    }

    /// <summary>
    /// Sets the categories.
    /// </summary>
    public ApexAxisOptions SetCategories(params string[] categories) {
        Categories = categories;
        return this;
    }

    /// <summary>
    /// Configures the axis title.
    /// </summary>
    public ApexAxisOptions AxisTitle(System.Action<ApexAxisTitle> configure) {
        Title ??= new ApexAxisTitle();
        configure(Title);
        return this;
    }

    /// <summary>
    /// Configures the axis labels.
    /// </summary>
    public ApexAxisOptions AxisLabels(System.Action<ApexAxisLabels> configure) {
        Labels ??= new ApexAxisLabels();
        configure(Labels);
        return this;
    }

    /// <summary>
    /// Sets the minimum and maximum values.
    /// </summary>
    public ApexAxisOptions Range(double min, double max) {
        Min = min;
        Max = max;
        return this;
    }
}

/// <summary>
/// Represents axis title configuration.
/// </summary>
public class ApexAxisTitle {
    /// <summary>
    /// Gets or sets the title text.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the style configuration.
    /// </summary>
    [JsonPropertyName("style")]
    public ApexTextStyle? Style { get; set; }

    /// <summary>
    /// Sets the title text.
    /// </summary>
    public ApexAxisTitle SetText(string text) {
        Text = text;
        return this;
    }

    /// <summary>
    /// Configures the title style.
    /// </summary>
    public ApexAxisTitle SetStyle(System.Action<ApexTextStyle> configure) {
        Style ??= new ApexTextStyle();
        configure(Style);
        return this;
    }
}

/// <summary>
/// Represents axis labels configuration.
/// </summary>
public class ApexAxisLabels {
    /// <summary>
    /// Gets or sets whether to show labels.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }

    /// <summary>
    /// Gets or sets the rotation angle.
    /// </summary>
    [JsonPropertyName("rotate")]
    public int? Rotate { get; set; }

    /// <summary>
    /// Gets or sets the style configuration.
    /// </summary>
    [JsonPropertyName("style")]
    public ApexTextStyle? Style { get; set; }

    /// <summary>
    /// Sets whether to show labels.
    /// </summary>
    public ApexAxisLabels ShowLabels(bool show) {
        Show = show;
        return this;
    }

    /// <summary>
    /// Sets the rotation angle.
    /// </summary>
    public ApexAxisLabels RotateLabels(int angle) {
        Rotate = angle;
        return this;
    }

    /// <summary>
    /// Configures the label style.
    /// </summary>
    public ApexAxisLabels SetStyle(System.Action<ApexTextStyle> configure) {
        Style ??= new ApexTextStyle();
        configure(Style);
        return this;
    }
}

/// <summary>
/// Represents text style configuration.
/// </summary>
public class ApexTextStyle {
    /// <summary>
    /// Gets or sets the font size.
    /// </summary>
    [JsonPropertyName("fontSize")]
    public string? FontSize { get; set; }

    /// <summary>
    /// Gets or sets the font family.
    /// </summary>
    [JsonPropertyName("fontFamily")]
    public string? FontFamily { get; set; }

    /// <summary>
    /// Gets or sets the font weight.
    /// </summary>
    [JsonPropertyName("fontWeight")]
    public string? FontWeight { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Sets the font size.
    /// </summary>
    public ApexTextStyle SetFontSize(string size) {
        FontSize = size;
        return this;
    }

    /// <summary>
    /// Sets the font family.
    /// </summary>
    public ApexTextStyle SetFontFamily(string family) {
        FontFamily = family;
        return this;
    }

    /// <summary>
    /// Sets the font weight.
    /// </summary>
    public ApexTextStyle SetFontWeight(string weight) {
        FontWeight = weight;
        return this;
    }

    /// <summary>
    /// Sets the color.
    /// </summary>
    public ApexTextStyle SetColor(string color) {
        Color = color;
        return this;
    }
}