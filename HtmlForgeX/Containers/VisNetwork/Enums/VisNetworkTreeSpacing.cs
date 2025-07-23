using System.Text.Json.Serialization;

namespace HtmlForgeX;

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