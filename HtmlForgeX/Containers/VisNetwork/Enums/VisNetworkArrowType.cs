using System.Text.Json.Serialization;

namespace HtmlForgeX;

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