using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents radar chart specific options.
/// </summary>
public class ApexRadarOptions {
    /// <summary>
    /// Gets or sets the size of the chart.
    /// </summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

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
    /// Gets or sets the polygons configuration.
    /// </summary>
    [JsonPropertyName("polygons")]
    public ApexPolygons? Polygons { get; set; }

    /// <summary>
    /// Sets the chart size.
    /// </summary>
    public ApexRadarOptions ChartSize(int size) {
        Size = size;
        return this;
    }

    /// <summary>
    /// Sets the offset.
    /// </summary>
    public ApexRadarOptions Offset(int x, int y) {
        OffsetX = x;
        OffsetY = y;
        return this;
    }

    /// <summary>
    /// Sets the polygons stroke colors.
    /// </summary>
    public ApexRadarOptions PolygonsStrokeColors(string color) {
        Polygons ??= new ApexPolygons();
        Polygons.StrokeColors = color;
        return this;
    }

    /// <summary>
    /// Sets the polygons stroke width.
    /// </summary>
    public ApexRadarOptions PolygonsStrokeWidth(int width) {
        Polygons ??= new ApexPolygons();
        Polygons.StrokeWidth = width;
        return this;
    }

    /// <summary>
    /// Sets the polygons fill colors.
    /// </summary>
    public ApexRadarOptions PolygonsFillColors(string[] colors) {
        Polygons ??= new ApexPolygons();
        Polygons.Fill = new ApexPolygonsFill { Colors = colors };
        return this;
    }
}

/// <summary>
/// Represents polygons configuration for radar chart.
/// </summary>
public class ApexPolygons {
    /// <summary>
    /// Gets or sets the stroke colors.
    /// </summary>
    [JsonPropertyName("strokeColors")]
    public string? StrokeColors { get; set; }

    /// <summary>
    /// Gets or sets the stroke width.
    /// </summary>
    [JsonPropertyName("strokeWidth")]
    public int? StrokeWidth { get; set; }

    /// <summary>
    /// Gets or sets the fill configuration.
    /// </summary>
    [JsonPropertyName("fill")]
    public ApexPolygonsFill? Fill { get; set; }
}

/// <summary>
/// Represents polygons fill configuration.
/// </summary>
public class ApexPolygonsFill {
    /// <summary>
    /// Gets or sets the fill colors.
    /// </summary>
    [JsonPropertyName("colors")]
    public string[]? Colors { get; set; }
}