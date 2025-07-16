using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents radial bar chart specific options.
/// </summary>
public class ApexRadialBarOptions {
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
    /// Gets or sets the hollow configuration.
    /// </summary>
    [JsonPropertyName("hollow")]
    public ApexHollow? Hollow { get; set; }

    /// <summary>
    /// Gets or sets the track configuration.
    /// </summary>
    [JsonPropertyName("track")]
    public ApexTrack? Track { get; set; }

    /// <summary>
    /// Gets or sets the data labels configuration.
    /// </summary>
    [JsonPropertyName("dataLabels")]
    public ApexRadialDataLabels? DataLabels { get; set; }

    /// <summary>
    /// Sets the hollow size.
    /// </summary>
    public ApexRadialBarOptions HollowSize(string size) {
        Hollow ??= new ApexHollow();
        Hollow.Size = size;
        return this;
    }

    /// <summary>
    /// Sets the track background color.
    /// </summary>
    public ApexRadialBarOptions TrackBackground(string color) {
        Track ??= new ApexTrack();
        Track.Background = color;
        return this;
    }

    /// <summary>
    /// Sets the angle range.
    /// </summary>
    public ApexRadialBarOptions AngleRange(int start, int end) {
        StartAngle = start;
        EndAngle = end;
        return this;
    }
}

/// <summary>
/// Represents hollow configuration for radial bar.
/// </summary>
public class ApexHollow {
    /// <summary>
    /// Gets or sets the size percentage.
    /// </summary>
    [JsonPropertyName("size")]
    public string? Size { get; set; }

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    [JsonPropertyName("background")]
    public string? Background { get; set; }

    /// <summary>
    /// Gets or sets the margin.
    /// </summary>
    [JsonPropertyName("margin")]
    public int? Margin { get; set; }
}

/// <summary>
/// Represents track configuration for radial bar.
/// </summary>
public class ApexTrack {
    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    [JsonPropertyName("background")]
    public string? Background { get; set; }

    /// <summary>
    /// Gets or sets the stroke width.
    /// </summary>
    [JsonPropertyName("strokeWidth")]
    public string? StrokeWidth { get; set; }

    /// <summary>
    /// Gets or sets the opacity.
    /// </summary>
    [JsonPropertyName("opacity")]
    public double? Opacity { get; set; }
}

/// <summary>
/// Represents radial bar data labels configuration.
/// </summary>
public class ApexRadialDataLabels {
    /// <summary>
    /// Gets or sets whether to show labels.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }

    /// <summary>
    /// Gets or sets the name configuration.
    /// </summary>
    [JsonPropertyName("name")]
    public ApexRadialLabel? Name { get; set; }

    /// <summary>
    /// Gets or sets the value configuration.
    /// </summary>
    [JsonPropertyName("value")]
    public ApexRadialLabel? Value { get; set; }
}

/// <summary>
/// Represents radial label configuration.
/// </summary>
public class ApexRadialLabel {
    /// <summary>
    /// Gets or sets whether to show the label.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }

    /// <summary>
    /// Gets or sets the font size.
    /// </summary>
    [JsonPropertyName("fontSize")]
    public string? FontSize { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }
}