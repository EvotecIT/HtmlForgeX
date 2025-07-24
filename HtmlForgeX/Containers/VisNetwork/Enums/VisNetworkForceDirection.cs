using System.Text.Json.Serialization;

namespace HtmlForgeX;

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