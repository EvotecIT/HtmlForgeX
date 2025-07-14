namespace HtmlForgeX;

/// <summary>
/// Available node shapes in VisNetwork.
/// </summary>
public enum VisNetworkNodeShape {
    /// <summary>
    /// Renders the node as an ellipse.
    /// </summary>
    Ellipse,

    /// <summary>
    /// Renders the node as a circle.
    /// </summary>
    Circle,

    /// <summary>
    /// Uses a database icon for the node.
    /// </summary>
    Database,

    /// <summary>
    /// Shows the node as a rectangular box.
    /// </summary>
    Box,

    /// <summary>
    /// Displays the node with a simple text label.
    /// </summary>
    Text,

    /// <summary>
    /// References an image specified by the <c>Image</c> property.
    /// </summary>
    Image,

    /// <summary>
    /// Similar to <see cref="Image"/> but clips the image to a circle.
    /// </summary>
    CircularImage,

    /// <summary>
    /// Renders the node as a diamond shape.
    /// </summary>
    Diamond,

    /// <summary>
    /// Shows the node as a small dot.
    /// </summary>
    Dot,

    /// <summary>
    /// Renders the node as a square.
    /// </summary>
    Square,

    /// <summary>
    /// Displays the node as a triangle pointing up.
    /// </summary>
    Triangle,

    /// <summary>
    /// Displays the node as a triangle pointing down.
    /// </summary>
    TriangleDown,

    /// <summary>
    /// Renders the node as a hexagon.
    /// </summary>
    Hexagon,

    /// <summary>
    /// Displays the node using a star icon.
    /// </summary>
    Star
}

/// <summary>
/// Helper methods for <see cref="VisNetworkNodeShape"/> values.
/// </summary>
public static class VisNetworkNodeShapeExtensions {
    /// <summary>
    /// Converts a <see cref="VisNetworkNodeShape"/> value to its string representation used by the library.
    /// </summary>
    /// <param name="shape">Shape to convert.</param>
    /// <returns>String representation understood by Vis Network.</returns>
    public static string EnumToString(this VisNetworkNodeShape shape) => shape switch {
        VisNetworkNodeShape.CircularImage => "circularImage",
        VisNetworkNodeShape.TriangleDown => "triangleDown",
        _ => shape.ToString().ToLower()
    };
}

/// <summary>
/// Defines arrow positioning on an edge.
/// </summary>
[Flags]
public enum VisNetworkArrows {
    /// <summary>
    /// No arrows are rendered on the edge.
    /// </summary>
    None = 0,

    /// <summary>
    /// Draws an arrow pointing towards the target node.
    /// </summary>
    To = 1,

    /// <summary>
    /// Draws an arrow pointing away from the source node.
    /// </summary>
    From = 2,

    /// <summary>
    /// Draws an arrow in the middle of the edge.
    /// </summary>
    Middle = 4
}

/// <summary>
/// Extension helpers for working with <see cref="VisNetworkArrows"/> values.
/// </summary>
public static class VisNetworkArrowExtensions {
    /// <summary>
    /// Converts a <see cref="VisNetworkArrows"/> flag combination to the string format expected by Vis Network.
    /// </summary>
    /// <param name="arrows">Flags describing which arrows are enabled.</param>
    /// <returns>Comma separated string used in JavaScript configuration.</returns>
    public static string EnumToString(this VisNetworkArrows arrows) {
        if (arrows == VisNetworkArrows.None) {
            return string.Empty;
        }

        var parts = new List<string>();
        if (arrows.HasFlag(VisNetworkArrows.From)) {
            parts.Add("from");
        }
        if (arrows.HasFlag(VisNetworkArrows.Middle)) {
            parts.Add("middle");
        }
        if (arrows.HasFlag(VisNetworkArrows.To)) {
            parts.Add("to");
        }

        return string.Join(", ", parts);
    }
}
