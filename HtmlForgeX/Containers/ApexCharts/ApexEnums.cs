using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents the position of elements in ApexCharts.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexPosition>))]
public enum ApexPosition {
    /// <summary>Positions element at the top.</summary>
    Top,
    /// <summary>Positions element at the right.</summary>
    Right,
    /// <summary>Positions element at the bottom.</summary>
    Bottom,
    /// <summary>Positions element at the left.</summary>
    Left,
    /// <summary>Positions element at the center.</summary>
    Center
}

/// <summary>
/// Represents the alignment options.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexAlign>))]
public enum ApexAlign {
    /// <summary>Left aligned.</summary>
    Left,
    /// <summary>Centered.</summary>
    Center,
    /// <summary>Right aligned.</summary>
    Right
}

/// <summary>
/// Represents curve types for line charts.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexCurve>))]
public enum ApexCurve {
    /// <summary>Smooth bezier curve.</summary>
    Smooth,
    /// <summary>Straight line segments.</summary>
    Straight,
    /// <summary>Stepped line segments.</summary>
    Stepline,
    /// <summary>Monotone cubic interpolation.</summary>
    Monotone
}

/// <summary>
/// Represents the line cap style.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexLineCap>))]
public enum ApexLineCap {
    /// <summary>Flat line end.</summary>
    Butt,
    /// <summary>Square line end.</summary>
    Square,
    /// <summary>Rounded line end.</summary>
    Round
}

/// <summary>
/// Represents fill types.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexFillType>))]
public enum ApexFillType {
    /// <summary>Solid color fill.</summary>
    Solid,
    /// <summary>Gradient fill.</summary>
    Gradient,
    /// <summary>Pattern fill.</summary>
    Pattern,
    /// <summary>Image fill.</summary>
    Image
}

/// <summary>
/// Represents gradient types.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexGradientType>))]
public enum ApexGradientType {
    /// <summary>Horizontal gradient.</summary>
    Horizontal,
    /// <summary>Vertical gradient.</summary>
    Vertical,
    /// <summary>Diagonal gradient (top-left to bottom-right).</summary>
    Diagonal1,
    /// <summary>Diagonal gradient (bottom-left to top-right).</summary>
    Diagonal2,
    /// <summary>Radial gradient.</summary>
    Radial
}

/// <summary>
/// Represents gradient shades.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexGradientShade>))]
public enum ApexGradientShade {
    /// <summary>Light gradient shade.</summary>
    Light,
    /// <summary>Dark gradient shade.</summary>
    Dark
}

/// <summary>
/// Represents pattern styles.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexPatternStyle>))]
public enum ApexPatternStyle {
    /// <summary>Vertical line pattern.</summary>
    VerticalLines,
    /// <summary>Horizontal line pattern.</summary>
    HorizontalLines,
    /// <summary>Slanted line pattern.</summary>
    SlantedLines,
    /// <summary>Square pattern.</summary>
    Squares,
    /// <summary>Circle pattern.</summary>
    Circles
}

/// <summary>
/// Represents axis types.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexAxisType>))]
public enum ApexAxisType {
    /// <summary>Categorical axis.</summary>
    Category,
    /// <summary>Date/time axis.</summary>
    Datetime,
    /// <summary>Numeric axis.</summary>
    Numeric
}

/// <summary>
/// Represents text anchor positions.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexTextAnchor>))]
public enum ApexTextAnchor {
    /// <summary>Start of the text anchor.</summary>
    Start,
    /// <summary>Middle of the text anchor.</summary>
    Middle,
    /// <summary>End of the text anchor.</summary>
    End
}

/// <summary>
/// Represents the orientation.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexOrientation>))]
public enum ApexOrientation {
    /// <summary>Horizontal orientation.</summary>
    Horizontal,
    /// <summary>Vertical orientation.</summary>
    Vertical
}