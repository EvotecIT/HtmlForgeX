namespace HtmlForgeX;

/// <summary>
/// Represents the position of chart elements.
/// </summary>
public enum ChartJsPosition {
    /// <summary>
    /// Position at the top.
    /// </summary>
    Top,
    /// <summary>
    /// Position at the bottom.
    /// </summary>
    Bottom,
    /// <summary>
    /// Position at the left.
    /// </summary>
    Left,
    /// <summary>
    /// Position at the right.
    /// </summary>
    Right,
    /// <summary>
    /// Position at the center.
    /// </summary>
    Center
}

/// <summary>
/// Represents the alignment of chart elements.
/// </summary>
public enum ChartJsAlign {
    /// <summary>
    /// Align to start.
    /// </summary>
    Start,
    /// <summary>
    /// Align to center.
    /// </summary>
    Center,
    /// <summary>
    /// Align to end.
    /// </summary>
    End
}

/// <summary>
/// Represents the interaction mode for tooltips and hover.
/// </summary>
public enum ChartJsInteractionMode {
    /// <summary>
    /// Find items at the same index.
    /// </summary>
    Index,
    /// <summary>
    /// Find items in the same dataset.
    /// </summary>
    Dataset,
    /// <summary>
    /// Find the nearest items.
    /// </summary>
    Nearest,
    /// <summary>
    /// Find items at the exact pointer position.
    /// </summary>
    Point,
    /// <summary>
    /// Find items in x direction.
    /// </summary>
    X,
    /// <summary>
    /// Find items in y direction.
    /// </summary>
    Y
}

/// <summary>
/// Represents the axis type.
/// </summary>
public enum ChartJsAxisType {
    /// <summary>
    /// Linear scale.
    /// </summary>
    Linear,
    /// <summary>
    /// Logarithmic scale.
    /// </summary>
    Logarithmic,
    /// <summary>
    /// Category scale.
    /// </summary>
    Category,
    /// <summary>
    /// Time scale.
    /// </summary>
    Time,
    /// <summary>
    /// Time series scale.
    /// </summary>
    TimeSeries,
    /// <summary>
    /// Radial linear scale.
    /// </summary>
    RadialLinear
}

/// <summary>
/// Represents the font style.
/// </summary>
public enum ChartJsFontStyle {
    /// <summary>
    /// Normal font style.
    /// </summary>
    Normal,
    /// <summary>
    /// Italic font style.
    /// </summary>
    Italic,
    /// <summary>
    /// Oblique font style.
    /// </summary>
    Oblique
}

/// <summary>
/// Represents the font weight.
/// </summary>
public enum ChartJsFontWeight {
    /// <summary>
    /// Normal weight.
    /// </summary>
    Normal,
    /// <summary>
    /// Bold weight.
    /// </summary>
    Bold,
    /// <summary>
    /// Lighter weight.
    /// </summary>
    Lighter,
    /// <summary>
    /// Bolder weight.
    /// </summary>
    Bolder
}

/// <summary>
/// Represents the point style.
/// </summary>
public enum ChartJsPointStyle {
    /// <summary>
    /// Circle point.
    /// </summary>
    Circle,
    /// <summary>
    /// Cross point.
    /// </summary>
    Cross,
    /// <summary>
    /// Cross rotated point.
    /// </summary>
    CrossRot,
    /// <summary>
    /// Dash point.
    /// </summary>
    Dash,
    /// <summary>
    /// Line point.
    /// </summary>
    Line,
    /// <summary>
    /// Rectangle point.
    /// </summary>
    Rect,
    /// <summary>
    /// Rounded rectangle point.
    /// </summary>
    RectRounded,
    /// <summary>
    /// Rotated rectangle point.
    /// </summary>
    RectRot,
    /// <summary>
    /// Star point.
    /// </summary>
    Star,
    /// <summary>
    /// Triangle point.
    /// </summary>
    Triangle
}

/// <summary>
/// Represents the border cap style.
/// </summary>
public enum ChartJsBorderCapStyle {
    /// <summary>
    /// Butt cap style.
    /// </summary>
    Butt,
    /// <summary>
    /// Round cap style.
    /// </summary>
    Round,
    /// <summary>
    /// Square cap style.
    /// </summary>
    Square
}

/// <summary>
/// Represents the border join style.
/// </summary>
public enum ChartJsBorderJoinStyle {
    /// <summary>
    /// Bevel join style.
    /// </summary>
    Bevel,
    /// <summary>
    /// Round join style.
    /// </summary>
    Round,
    /// <summary>
    /// Miter join style.
    /// </summary>
    Miter
}