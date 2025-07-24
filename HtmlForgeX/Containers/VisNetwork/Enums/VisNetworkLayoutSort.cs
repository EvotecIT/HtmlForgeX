using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Defines sorting modes for hierarchical layouts.
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