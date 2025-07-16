using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents the position of elements in ApexCharts.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexPosition>))]
public enum ApexPosition {
    Top,
    Right,
    Bottom,
    Left,
    Center
}

/// <summary>
/// Represents the alignment options.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexAlign>))]
public enum ApexAlign {
    Left,
    Center,
    Right
}

/// <summary>
/// Represents curve types for line charts.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexCurve>))]
public enum ApexCurve {
    Smooth,
    Straight,
    Stepline,
    Monotone
}

/// <summary>
/// Represents the line cap style.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexLineCap>))]
public enum ApexLineCap {
    Butt,
    Square,
    Round
}

/// <summary>
/// Represents fill types.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexFillType>))]
public enum ApexFillType {
    Solid,
    Gradient,
    Pattern,
    Image
}

/// <summary>
/// Represents gradient types.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexGradientType>))]
public enum ApexGradientType {
    Horizontal,
    Vertical,
    Diagonal1,
    Diagonal2,
    Radial
}

/// <summary>
/// Represents gradient shades.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexGradientShade>))]
public enum ApexGradientShade {
    Light,
    Dark
}

/// <summary>
/// Represents pattern styles.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexPatternStyle>))]
public enum ApexPatternStyle {
    VerticalLines,
    HorizontalLines,
    SlantedLines,
    Squares,
    Circles
}

/// <summary>
/// Represents axis types.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexAxisType>))]
public enum ApexAxisType {
    Category,
    Datetime,
    Numeric
}

/// <summary>
/// Represents text anchor positions.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexTextAnchor>))]
public enum ApexTextAnchor {
    Start,
    Middle,
    End
}

/// <summary>
/// Represents the orientation.
/// </summary>
[JsonConverter(typeof(ApexEnumConverter<ApexOrientation>))]
public enum ApexOrientation {
    Horizontal,
    Vertical
}