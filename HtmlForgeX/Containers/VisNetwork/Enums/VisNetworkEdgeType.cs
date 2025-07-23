using System.Text.Json.Serialization;

namespace HtmlForgeX;

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