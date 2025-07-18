using System.Text.Json.Serialization;

namespace HtmlForgeX;

#region Node Enums

/// <summary>
/// Predefined node shapes available in VisNetwork.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkNodeShape>))]
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
    Star,
    Icon,
    Custom
}

/// <summary>
/// Text alignment options for labels and other text elements.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkAlign>))]
public enum VisNetworkAlign {
    Left,
    Center,
    Right
}

/// <summary>
/// Multi-line text formatting options for labels.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkMulti>))]
public enum VisNetworkMulti {
    False,
    True,
    Html,
    Markdown
}

/// <summary>
/// Border dash pattern options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkBorderDashes>))]
public enum VisNetworkBorderDashes {
    False,
    True,
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
    Arrow,
    Bar,
    Circle,
    Image,
    Vee
}

/// <summary>
/// Smooth curve types for edges.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkSmoothType>))]
public enum VisNetworkSmoothType {
    Dynamic,
    Continuous,
    Discrete,
    Diagonally,
    Straightcross,
    Horizontal,
    Vertical,
    Curvedcw,
    Curvedccw,
    Cubicbezier
}

/// <summary>
/// Edge endpoint types.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkEdgeType>))]
public enum VisNetworkEdgeType {
    Arrow,
    Bar,
    Circle
}

#endregion

#region Physics Enums

/// <summary>
/// Physics solver algorithms for network simulation.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkPhysicsSolver>))]
public enum VisNetworkPhysicsSolver {
    BarnesHut,
    ForceAtlas2based,
    Repulsion,
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
    Ud,  // up-down
    Du,  // down-up
    Lr,  // left-right
    Rl   // right-left
}

/// <summary>
/// Sorting methods for hierarchical layout.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkLayoutSort>))]
public enum VisNetworkLayoutSort {
    Hubsize,
    Directed
}

/// <summary>
/// Tree spacing methods for hierarchical layout.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkTreeSpacing>))]
public enum VisNetworkTreeSpacing {
    EdgeMinimization,
    NodeDistance
}

#endregion

#region Interaction Enums

/// <summary>
/// Keyboard navigation speed options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkKeyboardSpeed>))]
public enum VisNetworkKeyboardSpeed {
    X,
    Y,
    Zoom
}

#endregion

#region Manipulation Enums

[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkLocale>))]
public enum VisNetworkLocale {
    En,
    Es,
    De,
    Fr,
    It,
    Nl,
    Pt,
    Ru,
    Uk,
    Zh,
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

public class VisNetworkEnumConverter<T> : JsonConverter<T> where T : struct, Enum {
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
