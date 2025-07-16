using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents data labels configuration options for ApexCharts.
/// </summary>
public class ApexDataLabelsOptions {
    /// <summary>
    /// Gets or sets whether data labels are enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the text anchor position.
    /// </summary>
    [JsonPropertyName("textAnchor")]
    [JsonConverter(typeof(ApexEnumConverter<ApexTextAnchor>))]
    public ApexTextAnchor? TextAnchor { get; set; }

    /// <summary>
    /// Gets or sets the style configuration.
    /// </summary>
    [JsonPropertyName("style")]
    public ApexTextStyle? Style { get; set; }

    /// <summary>
    /// Gets or sets the offset X position.
    /// </summary>
    [JsonPropertyName("offsetX")]
    public int? OffsetX { get; set; }

    /// <summary>
    /// Gets or sets the offset Y position.
    /// </summary>
    [JsonPropertyName("offsetY")]
    public int? OffsetY { get; set; }

    /// <summary>
    /// Gets or sets the formatter function as a string.
    /// </summary>
    [JsonPropertyName("formatter")]
    public string? Formatter { get; set; }

    /// <summary>
    /// Enables or disables data labels.
    /// </summary>
    public ApexDataLabelsOptions Enable(bool enabled) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the text anchor position.
    /// </summary>
    public ApexDataLabelsOptions Anchor(ApexTextAnchor anchor) {
        TextAnchor = anchor;
        return this;
    }

    /// <summary>
    /// Sets the offset position.
    /// </summary>
    public ApexDataLabelsOptions Offset(int x, int y) {
        OffsetX = x;
        OffsetY = y;
        return this;
    }

    /// <summary>
    /// Configures the label style.
    /// </summary>
    public ApexDataLabelsOptions SetStyle(System.Action<ApexTextStyle> configure) {
        Style ??= new ApexTextStyle();
        configure(Style);
        return this;
    }

    /// <summary>
    /// Sets a custom formatter function.
    /// </summary>
    public ApexDataLabelsOptions SetFormatter(string formatter) {
        Formatter = formatter;
        return this;
    }
}