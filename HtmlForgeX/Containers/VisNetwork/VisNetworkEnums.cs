namespace HtmlForgeX;

/// <summary>
/// Available node shapes in VisNetwork.
/// </summary>
public enum VisNetworkNodeShape {
    Ellipse,
    Circle,
    Database,
    Box,
    Text,
    Image,
    CircularImage,
    Diamond,
    Dot,
    Square,
    Triangle,
    TriangleDown,
    Hexagon,
    Star
}

public static class VisNetworkNodeShapeExtensions {
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
    None = 0,
    To = 1,
    From = 2,
    Middle = 4
}

public static class VisNetworkArrowExtensions {
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
