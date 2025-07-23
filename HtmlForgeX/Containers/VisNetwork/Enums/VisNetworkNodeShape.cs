using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Predefined node shapes available in VisNetwork.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkNodeShape>))]
public enum VisNetworkNodeShape {
    /// <summary>
    /// Node is rendered as an ellipse.
    /// </summary>
    Ellipse,

    /// <summary>
    /// Node is rendered as a circle.
    /// </summary>
    Circle,

    /// <summary>
    /// Node is rendered as a database symbol.
    /// </summary>
    Database,

    /// <summary>
    /// Node is rendered as a box.
    /// </summary>
    Box,

    /// <summary>
    /// Node is rendered as a text label only.
    /// </summary>
    Text,

    /// <summary>
    /// Node is rendered as an image.
    /// </summary>
    Image,

    /// <summary>
    /// Node is rendered as a circular image.
    /// </summary>
    CircularImage,

    /// <summary>
    /// Node is rendered as a diamond.
    /// </summary>
    Diamond,

    /// <summary>
    /// Node is rendered as a dot.
    /// </summary>
    Dot,

    /// <summary>
    /// Node is rendered as a square.
    /// </summary>
    Square,

    /// <summary>
    /// Node is rendered as a triangle pointing up.
    /// </summary>
    Triangle,

    /// <summary>
    /// Node is rendered as a triangle pointing down.
    /// </summary>
    TriangleDown,

    /// <summary>
    /// Node is rendered as a hexagon.
    /// </summary>
    Hexagon,

    /// <summary>
    /// Node is rendered as a star.
    /// </summary>
    Star,

    /// <summary>
    /// Node is rendered using an icon font.
    /// </summary>
    Icon,

    /// <summary>
    /// Node uses a custom drawing routine.
    /// </summary>
    Custom
}