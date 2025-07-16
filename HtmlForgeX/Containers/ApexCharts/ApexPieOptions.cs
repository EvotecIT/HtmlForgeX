using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents pie chart specific options.
/// </summary>
public class ApexPieOptions {
    /// <summary>
    /// Gets or sets the donut size percentage.
    /// </summary>
    [JsonPropertyName("donut")]
    public ApexDonutOptions? Donut { get; set; }

    /// <summary>
    /// Gets or sets the start angle.
    /// </summary>
    [JsonPropertyName("startAngle")]
    public int? StartAngle { get; set; }

    /// <summary>
    /// Gets or sets the end angle.
    /// </summary>
    [JsonPropertyName("endAngle")]
    public int? EndAngle { get; set; }

    /// <summary>
    /// Gets or sets whether to expand on click.
    /// </summary>
    [JsonPropertyName("expandOnClick")]
    public bool? ExpandOnClick { get; set; }

    /// <summary>
    /// Gets or sets the offset X.
    /// </summary>
    [JsonPropertyName("offsetX")]
    public int? OffsetX { get; set; }

    /// <summary>
    /// Gets or sets the offset Y.
    /// </summary>
    [JsonPropertyName("offsetY")]
    public int? OffsetY { get; set; }

    /// <summary>
    /// Sets the donut size.
    /// </summary>
    public ApexPieOptions DonutSize(string size) {
        Donut ??= new ApexDonutOptions();
        Donut.Size = size;
        return this;
    }

    /// <summary>
    /// Sets the angle range.
    /// </summary>
    public ApexPieOptions AngleRange(int start, int end) {
        StartAngle = start;
        EndAngle = end;
        return this;
    }

    /// <summary>
    /// Sets the offset.
    /// </summary>
    public ApexPieOptions Offset(int x, int y) {
        OffsetX = x;
        OffsetY = y;
        return this;
    }
}

/// <summary>
/// Represents donut chart specific options.
/// </summary>
public class ApexDonutOptions {
    /// <summary>
    /// Gets or sets the donut size percentage.
    /// </summary>
    [JsonPropertyName("size")]
    public string? Size { get; set; }

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    [JsonPropertyName("background")]
    public string? Background { get; set; }

    /// <summary>
    /// Gets or sets the labels configuration.
    /// </summary>
    [JsonPropertyName("labels")]
    public ApexDonutLabels? Labels { get; set; }
}

/// <summary>
/// Represents donut labels configuration.
/// </summary>
public class ApexDonutLabels {
    /// <summary>
    /// Gets or sets whether to show labels.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }
}