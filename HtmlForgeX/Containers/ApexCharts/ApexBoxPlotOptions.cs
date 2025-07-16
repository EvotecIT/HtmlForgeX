using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents boxplot chart specific options.
/// </summary>
public class ApexBoxPlotOptions {
    /// <summary>
    /// Gets or sets the colors for upper values.
    /// </summary>
    [JsonPropertyName("colors")]
    public ApexBoxPlotColors? Colors { get; set; }

    /// <summary>
    /// Sets the upper colors.
    /// </summary>
    public ApexBoxPlotOptions ColorsUpper(string color) {
        Colors ??= new ApexBoxPlotColors();
        Colors.Upper = color;
        return this;
    }

    /// <summary>
    /// Sets the lower colors.
    /// </summary>
    public ApexBoxPlotOptions ColorsLower(string color) {
        Colors ??= new ApexBoxPlotColors();
        Colors.Lower = color;
        return this;
    }
}

/// <summary>
/// Represents boxplot colors configuration.
/// </summary>
public class ApexBoxPlotColors {
    /// <summary>
    /// Gets or sets the upper color.
    /// </summary>
    [JsonPropertyName("upper")]
    public string? Upper { get; set; }

    /// <summary>
    /// Gets or sets the lower color.
    /// </summary>
    [JsonPropertyName("lower")]
    public string? Lower { get; set; }
}