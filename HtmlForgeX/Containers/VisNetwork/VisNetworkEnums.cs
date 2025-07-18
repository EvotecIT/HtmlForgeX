using System.Text.Json.Serialization;

namespace HtmlForgeX;

#region Node Enums

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

/// <summary>
/// Text alignment options for labels and other text elements.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkAlign>))]
public enum VisNetworkAlign {
    /// <summary>
    /// Align text to the left.
    /// </summary>
    Left,

    /// <summary>
    /// Center text.
    /// </summary>
    Center,

    /// <summary>
    /// Align text to the right.
    /// </summary>
    Right
}

/// <summary>
/// Multi-line text formatting options for labels.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkMulti>))]
public enum VisNetworkMulti {
    /// <summary>
    /// Multi-line text is disabled.
    /// </summary>
    False,

    /// <summary>
    /// Multi-line text is enabled.
    /// </summary>
    True,

    /// <summary>
    /// Interpret text as HTML markup.
    /// </summary>
    Html,

    /// <summary>
    /// Interpret text as Markdown.
    /// </summary>
    Markdown
}

/// <summary>
/// Border dash pattern options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkBorderDashes>))]
public enum VisNetworkBorderDashes {
    /// <summary>
    /// Use solid borders.
    /// </summary>
    False,

    /// <summary>
    /// Use dashed borders.
    /// </summary>
    True,

    /// <summary>
    /// Custom dash pattern specified by an array.
    /// </summary>
    Array
}

#endregion

#region Edge Enums

/// <summary>
/// Color inheritance options for edges.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkColorInherit>))]
public enum VisNetworkColorInherit {
    /// <summary>
    /// No color inheritance.
    /// </summary>
    False,
    
    /// <summary>
    /// Inherit color from source node.
    /// </summary>
    From,
    
    /// <summary>
    /// Inherit color from target node.
    /// </summary>
    To,
    
    /// <summary>
    /// Inherit color from both nodes (gradient).
    /// </summary>
    Both
}

/// <summary>
/// Force direction options for smooth edges.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkForceDirection>))]  
public enum VisNetworkForceDirection {
    /// <summary>
    /// No force direction.
    /// </summary>
    None,
    
    /// <summary>
    /// Force horizontal direction.
    /// </summary>
    Horizontal,
    
    /// <summary>
    /// Force vertical direction.
    /// </summary>
    Vertical
}

/// <summary>
/// Arrow type options for edge endpoints.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkArrowType>))]
public enum VisNetworkArrowType {
    /// <summary>
    /// Standard arrow head.
    /// </summary>
    Arrow,

    /// <summary>
    /// Bar at the end of the edge.
    /// </summary>
    Bar,

    /// <summary>
    /// Circular endpoint.
    /// </summary>
    Circle,

    /// <summary>
    /// Image used as an arrow head.
    /// </summary>
    Image,

    /// <summary>
    /// Vee shaped arrow head.
    /// </summary>
    Vee
}

/// <summary>
/// Smooth curve types for edges.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkSmoothType>))]
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

/// <summary>
/// Edge endpoint types.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkEdgeType>))]
public enum VisNetworkEdgeType {
    /// <summary>
    /// Standard arrow between nodes.
    /// </summary>
    Arrow,

    /// <summary>
    /// Bar shaped connection.
    /// </summary>
    Bar,

    /// <summary>
    /// Circular connection point.
    /// </summary>
    Circle
}

#endregion

#region Physics Enums

/// <summary>
/// Physics solver algorithms for network simulation.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkPhysicsSolver>))]
public enum VisNetworkPhysicsSolver {
    /// <summary>
    /// Uses the Barnes-Hut algorithm.
    /// </summary>
    BarnesHut,

    /// <summary>
    /// Uses the ForceAtlas2 based algorithm.
    /// </summary>
    ForceAtlas2based,

    /// <summary>
    /// Uses a repulsion algorithm.
    /// </summary>
    Repulsion,

    /// <summary>
    /// Uses hierarchical repulsion.
    /// </summary>
    HierarchicalRepulsion
}

#endregion

#region Layout Enums

/// <summary>
/// Shake towards options for hierarchical layout.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkShakeTowards>))]  
public enum VisNetworkShakeTowards {
    /// <summary>
    /// Shake towards roots.
    /// </summary>
    Roots,
    
    /// <summary>
    /// Shake towards leaves.
    /// </summary>
    Leaves
}

/// <summary>
/// Hierarchical layout direction options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkLayoutDirection>))]
public enum VisNetworkLayoutDirection {
    /// <summary>
    /// Top to bottom layout.
    /// </summary>
    Ud,  // up-down

    /// <summary>
    /// Bottom to top layout.
    /// </summary>
    Du,  // down-up

    /// <summary>
    /// Left to right layout.
    /// </summary>
    Lr,  // left-right

    /// <summary>
    /// Right to left layout.
    /// </summary>
    Rl   // right-left
}

/// <summary>
/// Sorting methods for hierarchical layout.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkLayoutSort>))]
public enum VisNetworkLayoutSort {
    /// <summary>
    /// Sort by hub size.
    /// </summary>
    Hubsize,

    /// <summary>
    /// Sort in directed order.
    /// </summary>
    Directed
}

/// <summary>
/// Tree spacing methods for hierarchical layout.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkTreeSpacing>))]
public enum VisNetworkTreeSpacing {
    /// <summary>
    /// Minimize edge crossings.
    /// </summary>
    EdgeMinimization,

    /// <summary>
    /// Keep distance between nodes consistent.
    /// </summary>
    NodeDistance
}

#endregion

#region Interaction Enums

/// <summary>
/// Keyboard navigation speed options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkKeyboardSpeed>))]
public enum VisNetworkKeyboardSpeed {
    /// <summary>
    /// Horizontal movement speed.
    /// </summary>
    X,

    /// <summary>
    /// Vertical movement speed.
    /// </summary>
    Y,

    /// <summary>
    /// Zoom speed.
    /// </summary>
    Zoom
}

#endregion

#region Manipulation Enums

/// <summary>
/// Supported locales for VisNetwork interface texts.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkLocale>))]
public enum VisNetworkLocale {
    /// <summary>
    /// English locale.
    /// </summary>
    En,

    /// <summary>
    /// Spanish locale.
    /// </summary>
    Es,

    /// <summary>
    /// German locale.
    /// </summary>
    De,

    /// <summary>
    /// French locale.
    /// </summary>
    Fr,

    /// <summary>
    /// Italian locale.
    /// </summary>
    It,

    /// <summary>
    /// Dutch locale.
    /// </summary>
    Nl,

    /// <summary>
    /// Portuguese locale.
    /// </summary>
    Pt,

    /// <summary>
    /// Russian locale.
    /// </summary>
    Ru,

    /// <summary>
    /// Ukrainian locale.
    /// </summary>
    Uk,

    /// <summary>
    /// Chinese locale.
    /// </summary>
    Zh,

    /// <summary>
    /// Japanese locale.
    /// </summary>
    Ja
}

#endregion

#region Legacy Compatibility

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

#endregion

#region Base Converter

/// <summary>
/// Custom JSON converter handling serialization of VisNetwork enums.
/// </summary>
public class VisNetworkEnumConverter<T> : JsonConverter<T> where T : struct, Enum {
    /// <summary>
    /// Reads a VisNetwork enum value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The enum type being converted.</param>
    /// <param name="options">Serializer options.</param>
    /// <returns>The parsed enum value or default.</returns>
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        if (value == null) {
            return default;
        }

        // Handle special cases
        if (typeof(T) == typeof(VisNetworkLayoutDirection)) {
            value = value.ToUpperInvariant();
        } else if (typeof(T) == typeof(VisNetworkSmoothType)) {
            value = char.ToUpperInvariant(value[0]) + value.Substring(1);
        } else if (typeof(T) == typeof(VisNetworkNodeShape)) {
            if (value == "circularImage") return (T)(object)VisNetworkNodeShape.CircularImage;
            if (value == "triangleDown") return (T)(object)VisNetworkNodeShape.TriangleDown;
            value = char.ToUpperInvariant(value[0]) + value.Substring(1);
        } else {
            // Default: capitalize first letter
            value = char.ToUpperInvariant(value[0]) + value.Substring(1);
        }

        if (Enum.TryParse<T>(value, true, out var result)) {
            return result;
        }

        return default;
    }

    /// <summary>
    /// Writes a VisNetwork enum value to JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">Value to serialize.</param>
    /// <param name="options">Serializer options.</param>
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
        var stringValue = value.ToString();
        
        // Handle special cases
        if (typeof(T) == typeof(VisNetworkLayoutDirection)) {
            writer.WriteStringValue(stringValue.ToUpperInvariant());
        } else if (typeof(T) == typeof(VisNetworkNodeShape)) {
            switch (value) {
                case VisNetworkNodeShape.CircularImage:
                    writer.WriteStringValue("circularImage");
                    break;
                case VisNetworkNodeShape.TriangleDown:
                    writer.WriteStringValue("triangleDown");
                    break;
                default:
                    writer.WriteStringValue(stringValue.ToLowerInvariant());
                    break;
            }
        } else if (typeof(T) == typeof(VisNetworkPhysicsSolver)) {
            switch (value) {
                case VisNetworkPhysicsSolver.BarnesHut:
                    writer.WriteStringValue("barnesHut");
                    break;
                case VisNetworkPhysicsSolver.ForceAtlas2based:
                    writer.WriteStringValue("forceAtlas2Based");
                    break;
                case VisNetworkPhysicsSolver.HierarchicalRepulsion:
                    writer.WriteStringValue("hierarchicalRepulsion");
                    break;
                default:
                    writer.WriteStringValue(stringValue.ToLowerInvariant());
                    break;
            }
        } else if (typeof(T) == typeof(VisNetworkLocale)) {
            writer.WriteStringValue(stringValue.ToLowerInvariant());
        } else if (typeof(T) == typeof(VisNetworkMulti)) {
            if (value.Equals(VisNetworkMulti.False)) {
                writer.WriteBooleanValue(false);
            } else if (value.Equals(VisNetworkMulti.True)) {
                writer.WriteBooleanValue(true);
            } else {
                writer.WriteStringValue(stringValue.ToLowerInvariant());
            }
        } else if (typeof(T) == typeof(VisNetworkForceDirection)) {
            if (value.Equals(VisNetworkForceDirection.None)) {
                writer.WriteBooleanValue(false);
            } else {
                writer.WriteStringValue(stringValue.ToLowerInvariant());
            }
        } else if (typeof(T) == typeof(VisNetworkColorInherit)) {
            if (value.Equals(VisNetworkColorInherit.False)) {
                writer.WriteBooleanValue(false);
            } else {
                writer.WriteStringValue(stringValue.ToLowerInvariant());
            }
        } else {
            // Default: lowercase
            writer.WriteStringValue(stringValue.ToLowerInvariant());
        }
    }
}

#endregion
