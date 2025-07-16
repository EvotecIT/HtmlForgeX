using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents stroke configuration options for ApexCharts.
/// </summary>
public class ApexStrokeOptions {
    /// <summary>
    /// Gets or sets whether to show stroke.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }

    /// <summary>
    /// Gets or sets the curve type.
    /// </summary>
    [JsonPropertyName("curve")]
    [JsonConverter(typeof(ApexEnumConverter<ApexCurve>))]
    public ApexCurve? Curve { get; set; }

    /// <summary>
    /// Gets or sets the line cap.
    /// </summary>
    [JsonPropertyName("lineCap")]
    [JsonConverter(typeof(ApexEnumConverter<ApexLineCap>))]
    public ApexLineCap? LineCap { get; set; }

    /// <summary>
    /// Gets or sets the stroke colors.
    /// </summary>
    [JsonPropertyName("colors")]
    public string[]? Colors { get; set; }

    /// <summary>
    /// Gets or sets the stroke width.
    /// </summary>
    [JsonPropertyName("width")]
    public object? Width { get; set; }

    /// <summary>
    /// Gets or sets the dash array.
    /// </summary>
    [JsonPropertyName("dashArray")]
    public object? DashArray { get; set; }

    /// <summary>
    /// Shows or hides the stroke.
    /// </summary>
    public ApexStrokeOptions ShowStroke(bool show) {
        Show = show;
        return this;
    }

    /// <summary>
    /// Sets the curve type.
    /// </summary>
    public ApexStrokeOptions SetCurve(ApexCurve curve) {
        Curve = curve;
        return this;
    }

    /// <summary>
    /// Sets the line cap.
    /// </summary>
    public ApexStrokeOptions SetLineCap(ApexLineCap lineCap) {
        LineCap = lineCap;
        return this;
    }

    /// <summary>
    /// Sets the stroke colors.
    /// </summary>
    public ApexStrokeOptions SetColors(params string[] colors) {
        Colors = colors;
        return this;
    }

    /// <summary>
    /// Sets the stroke width (single value or array).
    /// </summary>
    public ApexStrokeOptions SetWidth(object width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the dash array (single value or array).
    /// </summary>
    public ApexStrokeOptions SetDashArray(object dashArray) {
        DashArray = dashArray;
        return this;
    }
}