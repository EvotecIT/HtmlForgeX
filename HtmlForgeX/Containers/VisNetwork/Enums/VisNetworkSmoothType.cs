using System.Text.Json.Serialization;

namespace HtmlForgeX;

public enum VisNetworkSmoothType {
    /// <summary>
    /// Dynamically chooses the best curve type.
    /// </summary>
    Dynamic,

    /// <summary>
    /// Uses a continuous bezier curve.
    /// </summary>
    Continuous,

    /// <summary>
    /// Uses a discrete curve between points.
    /// </summary>
    Discrete,

    /// <summary>
    /// Diagonal straight line between points.
    /// </summary>
    Diagonally,

    /// <summary>
    /// Straight line crossing midpoints.
    /// </summary>
    Straightcross,

    /// <summary>
    /// Horizontal curve.
    /// </summary>
    Horizontal,

    /// <summary>
    /// Vertical curve.
    /// </summary>
    Vertical,

    /// <summary>
    /// Clockwise curved line.
    /// </summary>
    Curvedcw,

    /// <summary>
    /// Counter clockwise curved line.
    /// </summary>
    Curvedccw,

    /// <summary>
    /// Cubic bezier curve.
    /// </summary>
    Cubicbezier
}