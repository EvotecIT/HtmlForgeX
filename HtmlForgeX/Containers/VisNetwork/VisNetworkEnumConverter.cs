using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

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

/// <summary>
/// JSON converter for VisNetwork enumeration values.
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