using System.Text.Json.Serialization;

namespace HtmlForgeX;

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